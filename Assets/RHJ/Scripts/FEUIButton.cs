using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEUIButton : MonoBehaviour
{
    [SerializeField] GameObject parentUI;
    [SerializeField] GameObject FE;
    [SerializeField] GameObject Minigame;
    public void NotUseButton()
    {
        parentUI.SetActive(false);
        SojaExiles.MouseLook.Instance.mouseLock = false;
    }

    public void UseButton()
    {
        parentUI.SetActive(false);
        FE.SetActive(false);
        Minigame.SetActive(true);

    }
}
