﻿using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;


namespace FlowCanvas.Macros{

	[DoNotList]
	[Icon("MacroOut")]
	[Description("Defines the Output ports of the Macro.\nTo quickly create ports, you can also Drag&Drop a connection on top of this node!")]
	[ProtectedSingleton]
	public class MacroOutputNode : FlowNode{

		public override ParadoxNotion.Alignment2x2 iconAlignment{
			get {return ParadoxNotion.Alignment2x2.Default;}
		}

		private Macro macro{
			get {return (Macro)graph;}
		}

		protected override void RegisterPorts(){
			for (var i = 0; i < macro.outputDefinitions.Count; i++){
				var def = macro.outputDefinitions[i];
				if (def.type == typeof(Flow)){
					AddFlowInput(def.name, (f)=> {macro.exitActionMap[def.ID](f); }, def.ID );
				} else {
					macro.exitFunctionMap[def.ID] = AddValueInput(def.name, def.type, def.ID).GetObjectValue;
				}				
			}
		}


		///----------------------------------------------------------------------------------------------
		///---------------------------------------UNITY EDITOR-------------------------------------------
		#if UNITY_EDITOR

		protected override UnityEditor.GenericMenu OnContextMenu(UnityEditor.GenericMenu menu){
			return null;
		}

		protected override UnityEditor.GenericMenu OnDragAndDropPortContextMenu(UnityEditor.GenericMenu menu, Port port){
			if (port is ValueOutput || port is FlowOutput){
				menu.AddItem(new GUIContent(string.Format("Promote to new Output '{0}'", port.name)), false, ()=>{
					var def = new DynamicPortDefinition(port.name, port.type);
					if (macro.AddOutputDefinition(def)){
						GatherPorts();
						BinderConnection.Create(port, GetInputPort(def.ID));
					}
				});
			}
			return menu;
		}

		protected override void OnNodeInspectorGUI(){

			if (GUILayout.Button("Add Flow Output")){
				macro.AddOutputDefinition(new DynamicPortDefinition("Flow Output", typeof(Flow)));
				GatherPorts();
			}
			
			if (GUILayout.Button("Add Value Output")){
				EditorUtils.ShowPreferedTypesSelectionMenu(typeof(object), (t)=>
				{
					macro.AddOutputDefinition(new DynamicPortDefinition(string.Format("{0} Output", t.FriendlyName() ), t));
					GatherPorts();
				});
			}

			var options = new EditorUtils.ReorderableListOptions();
			options.allowRemove = true;
			EditorUtils.ReorderableList(macro.outputDefinitions, options, (i, picked)=>
			{
				var def = macro.outputDefinitions[i];
				GUILayout.BeginHorizontal();
				def.name = UnityEditor.EditorGUILayout.DelayedTextField(def.name, GUILayout.Width(150), GUILayout.ExpandWidth(true));
				GUI.enabled = def.type != typeof(Flow);
				EditorUtils.ButtonTypePopup("", def.type, (t)=>{ def.type = t; GatherPorts(); });
				GUI.enabled = true;
				GUILayout.EndHorizontal();
			});

			if (GUI.changed){
				GatherPorts();
			}
		}
			
		#endif
	}
}