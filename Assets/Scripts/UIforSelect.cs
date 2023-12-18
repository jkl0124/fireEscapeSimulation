using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIforSelect : MonoBehaviour
{

    public GameObject selectui;
    public ImageFade nextimgforfade;


    public void PushedButton()
    {
        selectui.SetActive(false);
        nextimgforfade.fadeinoutstart = true;
    }
}
