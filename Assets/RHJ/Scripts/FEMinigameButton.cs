using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEMinigameButton : MonoBehaviour
{
    [SerializeField] GameObject nowUI;
    [SerializeField] GameObject nextUI;
    [SerializeField] GameObject nowButton;
    [SerializeField] GameObject nextButton;


    public void Correct()
    {
        nowUI.SetActive(false);
        nowButton.SetActive(false);
        nextUI.SetActive(true);
        if (nextButton != null)
        {
            nextButton.SetActive(true);
        }
    }

    public void MouseLockdisable()
    {
        SojaExiles.MouseLook.Instance.mouseLock = false;
    }

}
