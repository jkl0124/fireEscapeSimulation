using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotCollisioncheck : MonoBehaviour
{
    private bool check = false;
    public ImageFade imgfade;
    public bool isauto = true;
    public bool shouldchecktoplayselect = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !check && !shouldchecktoplayselect)
        {
            check = true;

            imgfade.fadeinoutstart = true;
            Debug.Log("충돌");

        }

        else if (other.CompareTag("Player") && !check && shouldchecktoplayselect)
        {
            
            check = true;
            imgfade.fordestroy.SetActive(true);
            imgfade.fadeinoutstart = true;
            Debug.Log("충돌");

        }


    }
    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && check && !isauto)
        {
            if (imgfade.fordestroy != null)
                imgfade.fadeinoutstart = true;
            Debug.Log("나감");

        }
    }
    */
}
