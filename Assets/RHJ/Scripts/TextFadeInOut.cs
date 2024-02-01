using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFadeInOut : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform Target;
    [SerializeField] private TextMeshProUGUI textMeshPro;

    public bool fading = false;

    float fadeDuration = 1f;


    void Start()
    {
        textMeshPro.alpha = 0;
    }

    void Update()
    {
        if (Player)
        {
            float dist = Vector3.Distance(Player.position, Target.position);

            if (dist < 3 && !fading)
            {
                FadeOut();
                fading = true;
            }

            else if (dist >= 3 && fading)
            {
                FadeIn();
                fading = false;
            }

        }
    }


    public void FadeIn()
    {
        StartCoroutine(Fade(1, 0));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(0, 1));
    }

    public IEnumerator Fade(float alphaIn, float alphaOut)
    {
        float timer = 0;

        while (timer <= fadeDuration)
        {
            float progress = timer / fadeDuration;
            textMeshPro.alpha = Mathf.Lerp(alphaIn, alphaOut, progress);

            timer += Time.deltaTime;
            yield return null;
        }
    }
}
