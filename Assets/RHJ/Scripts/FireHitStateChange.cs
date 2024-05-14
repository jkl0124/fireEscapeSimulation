using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireHitStateChange : MonoBehaviour
{
    private Color Red_color;
    [SerializeField] GameObject Red_image;
    [SerializeField] GameObject UI;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Red_image.SetActive(true);
            StartCoroutine(RedFadeInOut());
            UI.SetActive(true);
            StateManager.Instance.UpdateHp(-7);
            StateManager.Instance.UpdateGas(3);
            StateManager.Instance.UpdateOxygen(-2);
        }
    }


    IEnumerator RedFadeInOut()
    {
        float startTime = Time.realtimeSinceStartup;
        Red_color = Red_image.GetComponent<Image>().color;

        while (Time.realtimeSinceStartup - startTime < 1f)
        {
            Red_image.GetComponent<Image>().color = new Color(Red_color.r, Red_color.g, Red_color.b, Mathf.Lerp(1, 0, Time.realtimeSinceStartup - startTime));
            yield return null;
        }
        Red_image.SetActive(false);
    }

}
