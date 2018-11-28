﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuto_Manager : MonoBehaviour
{
    public ScriptableTuto currentScriptableTuto;
    public GameObject menuTuto;
    public Text tutoTitleTxt;
    public Image tutoImg;
    public Text tutoTxt;
    private int currentSlideIdx = 0;
    public List<bool> tutoHasBeenDone;
    public List<ScriptableTuto> tutoList;
    private int tutoToDeactive;
    private int idxTuto;

    public GameObject buttonPrecedentSlide;

    public int tutoQuizzIdx;

    [Header ("Tuto Gallery Manager")]

    public Transform tutoGallery;



    public static Tuto_Manager tuto {get; private set;}

    private void Awake()
    {
        if (tuto == null)
        {
            DontDestroyOnLoad(gameObject);
            tuto = this;
        }
        else if (tuto != this)
        {
            Destroy(gameObject);
        }
    }

    public void ActivatingTuto(int tutoToActive)
    {
        idxTuto = tutoToActive;
        tutoToDeactive = tutoToActive;
        if (tutoHasBeenDone[tutoToActive] == false)
        {
            currentScriptableTuto = tutoList[tutoToActive];
            tutoTitleTxt.text = currentScriptableTuto.tutoTitle;
            menuTuto.SetActive(true);
            tutoImg.sprite = currentScriptableTuto.tutoImageBoard[currentSlideIdx];
            tutoTxt.text = currentScriptableTuto.tutoTextBoard[currentSlideIdx];
        }
    }

    public void MoveToNextSlide ()
    {
        if (currentSlideIdx == currentScriptableTuto.numberOfSlides - 1)
        {
            Debug.Log("YOOOOOOOOOOOOOO" + currentSlideIdx);
            currentSlideIdx = 0;
            menuTuto.SetActive(false);
            tutoHasBeenDone[tutoToDeactive] = true;
            Save_Manager.saving.TutoIsDone(tutoHasBeenDone);
            buttonPrecedentSlide.SetActive(false);

            if (tutoGallery.GetChild(idxTuto).gameObject.GetComponent<Button>().interactable == false)
            {
                tutoGallery.GetChild(idxTuto).gameObject.GetComponent<Button>().interactable = true;
            }

            if (currentScriptableTuto == tutoList[tutoQuizzIdx])
            {
                Interface_Manager.Instance.OpenARCamera();
            }
        }

        else 
        {
            buttonPrecedentSlide.SetActive(true);
            currentSlideIdx++;
            tutoImg.sprite = currentScriptableTuto.tutoImageBoard[currentSlideIdx];
            tutoTxt.text = currentScriptableTuto.tutoTextBoard[currentSlideIdx];
        } 

    }

    public void MoveToPrecedentSlide()
    {
        if(currentSlideIdx != 0)
        {
            currentSlideIdx--;
            tutoImg.sprite = currentScriptableTuto.tutoImageBoard[currentSlideIdx];
            tutoTxt.text = currentScriptableTuto.tutoTextBoard[currentSlideIdx];
            if(currentSlideIdx == 0)
            {
                buttonPrecedentSlide.SetActive(false);
            }
        }
    }

    //SAVE AND LOAD TUTO

    public void TutoState(List<bool> isTutoCheck)
    {
        for (int k = 0; k < tutoHasBeenDone.Count; k++)
        {
            tutoHasBeenDone[k] = isTutoCheck[k];
        }
    }

    public void LoadMenuTuto(List<bool> isTutoDone)
    {
        for (int i = 0; i < tutoList.Count; i++)
        {
            tutoGallery.GetChild(i).gameObject.GetComponent<Button>().interactable = isTutoDone[i];
        }
    }
}

