using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloserComeoutUI : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private Transform Player;
    public float fadeDuration = 1f;

    void Start()
    {

    }

    void Update()
    {
        if (Player)
        {
            float dist = Vector3.Distance(Player.position, transform.position);
            if (dist < 1)
            {
                FadeIn(UI);
            }

            else
            {
                FadeOut(UI);
            }

        }
    }



    IEnumerator FadeIn(GameObject ui)
    {
        float timer = 0;

        Renderer renderer = ui.GetComponent<Renderer>();
        Material mat = renderer.material;
        
        while (timer <= fadeDuration)
        {
            float progress = timer / fadeDuration;

            Color newColor = mat.color;
            newColor.a = Mathf.Lerp(0, 1, progress);

            mat.color = newColor;

            timer += Time.deltaTime;
            yield return null;
        }
    }



    IEnumerator FadeOut(GameObject ui)
    {
        float timer = 0;

        Renderer renderer = ui.GetComponent<Renderer>();
        Material mat = renderer.material;

        while (timer <= fadeDuration)
        {
            float progress = timer / fadeDuration;

            Color newColor = mat.color;
            newColor.a = Mathf.Lerp(1, 0, progress);

            mat.color = newColor;

            timer += Time.deltaTime;
            yield return null;
        }
    }



}
