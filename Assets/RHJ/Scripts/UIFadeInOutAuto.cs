using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeInOutAuto : MonoBehaviour
{

    [SerializeField] private Color color;
    [SerializeField] private TextMeshProUGUI tcolor;

    public float waitTime = 5f;

    float fadeDuration = 1f;
    void Start()
    {
        
        try
        {
            if (GetComponent<Image>() != null)
            {
                color = GetComponent<Image>().color;
                StartCoroutine(FadeInOut(0, 1));
            }
            else if (GetComponent<TextMeshProUGUI>() != null)
            {
                tcolor = GetComponent<TextMeshProUGUI>();
                StartCoroutine(TextFadeInOut(0, 1));
            }
            
        }
        catch (Exception e)
        {
            Debug.LogError("An error occurred in Start: " + e.Message);
        }

    }



    public IEnumerator FadeInOut(float alphaIn, float alphaOut)
    {
        float timer = 0;

        while (timer <= fadeDuration)
        {
            float progress = timer / fadeDuration;
            GetComponent<Image>().color = new Color(color.r, color.g, color.b, Mathf.Lerp(alphaIn, alphaOut, progress));

            timer += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        timer = 0;

        while (timer <= fadeDuration)
        {
            float progress = timer / fadeDuration;
            GetComponent<Image>().color = new Color(color.r, color.g, color.b, Mathf.Lerp(alphaOut, alphaIn, progress));

            timer += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }



    public IEnumerator TextFadeInOut(float alphaIn, float alphaOut)
    {
        float timer = 0;

        while (timer <= fadeDuration)
        {
            float progress = timer / fadeDuration;
           tcolor.alpha = Mathf.Lerp(alphaIn, alphaOut, progress);

            timer += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        timer = 0;

        while (timer <= fadeDuration)
        {
            float progress = timer / fadeDuration;
            tcolor.alpha = Mathf.Lerp(alphaOut, alphaIn, progress);

            timer += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
