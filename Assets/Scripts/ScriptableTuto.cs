﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable_Tuto", menuName = "Scriptable/Tuto", order = 1)]

public class ScriptableTuto : ScriptableObject {

    public Sprite[] tutoImageBoard;
    public string[] tutoTextBoard;
    public List<bool> isTutoDone;
    public int nbxTuto;
    public int numberOfSlides;

}
