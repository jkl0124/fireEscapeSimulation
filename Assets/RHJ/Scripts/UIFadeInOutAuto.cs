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
    public float fadeDuration = 1f;

    private void OnEnable()
    {
        StartCoroutine(FadeInOutRoutine());
    }

    private IEnumerator FadeInOutRoutine()
    {
        if (GetComponent<Image>() != null)
        {
            color = GetComponent<Image>().color;
            yield return StartCoroutine(FadeInOut(0, 1));
        }
        else if (GetComponent<TextMeshProUGUI>() != null)
        {
            tcolor = GetComponent<TextMeshProUGUI>();
            yield return StartCoroutine(TextFadeInOut(0, 1));
        }

        yield return new WaitForSeconds(waitTime);

        if (GetComponent<Image>() != null)
        {
            yield return StartCoroutine(FadeInOut(1, 0));
        }
        else if (GetComponent<TextMeshProUGUI>() != null)
        {
            yield return StartCoroutine(TextFadeInOut(1, 0));
        }

        gameObject.SetActive(false);
    }

    private IEnumerator FadeInOut(float alphaIn, float alphaOut)
    {
        float timer = 0;

        while (timer <= fadeDuration)
        {
            float progress = timer / fadeDuration;
            if (GetComponent<Image>() != null)
            {
                GetComponent<Image>().color = new Color(color.r, color.g, color.b, Mathf.Lerp(alphaIn, alphaOut, progress));
            }
            else if (GetComponent<TextMeshProUGUI>() != null)
            {
                tcolor.alpha = Mathf.Lerp(alphaIn, alphaOut, progress);
            }

            timer += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator TextFadeInOut(float alphaIn, float alphaOut)
    {
        float timer = 0;

        while (timer <= fadeDuration)
        {
            float progress = timer / fadeDuration;
            tcolor.alpha = Mathf.Lerp(alphaIn, alphaOut, progress);

            timer += Time.deltaTime;
            yield return null;
        }
    }
}
