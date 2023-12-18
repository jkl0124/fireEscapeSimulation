using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ImageFade : MonoBehaviour
{
    // 페이드 인/아웃할 이미지, 인스펙터(Inspector)에서 할당
    public List<Image> img;
    public bool fadeinoutstart = false;
    public bool fadeinisTrue = true;
    public List<Text> text;

    private bool finished = false;
    public GameObject fordestroy;

    void Update()
    {
        if (fadeinoutstart)
        {
            fadeinoutstart = false;
            if (fordestroy.tag == "autodestroy")
                StartCoroutine(FadeImageAuto()); 
            else
                StartCoroutine(FadeImage(fadeinisTrue));//fadeinisTrue가 true면 페이드인 호출, false면 페이드아웃 호출
        }
        if (finished)
            Destroy(fordestroy);
    }
    /*
    // 버튼 클릭시 호출될 메서드
    public void OnButtonClick()
    {
        // 클릭 시 이미지를 페이드 아웃(사라지게)합니다.
        StartCoroutine(FadeImage(true));
    }
    */


    public 

    // 이미지를 페이드 인/아웃하는 코루틴 메서드
    IEnumerator FadeImage(bool fadeAway)
    {
        // 불투명 -> 투명
        if (!fadeAway)
        {
            // 1초 동안 역순으로 반복
            for (float i = 3; i >= 0; i -= Time.deltaTime)
            {
                //float mappedValue = (originalValue - minValue) / (maxValue - minValue);
                float mappedValue = (i - 0) / (0.5f - 0);
                // i 값을 알파(투명도)로 설정하여 이미지 색상을 변경합니다.
                for (int a = 0; a < img.Count; a++)
                {
                    img[a].color = new Color(1, 1, 1, i);
                }
                for (int a = 0; a < text.Count; a++)
                {
                    text[a].color = new Color(1, 1, 1, i);
                }

                yield return null;
            }
            finished = true;
        }
        // 투명 -> 불투명
        else
        {
            
            // 1초 동안 반복
            for (float i = 0; i <= 3; i += Time.deltaTime)
            {
                //float mappedValue = (originalValue - minValue) / (maxValue - minValue);
                float mappedValue = (i - 0) / (0.5f - 0);
                // i 값을 알파(투명도)로 설정하여 이미지 색상을 변경합니다.
                for (int a = 0; a < img.Count; a++)
                {
                    img[a].color = new Color(1, 1, 1, i);
                }
                for (int a = 0; a < text.Count; a++)
                {
                    text[a].color = new Color(1, 1, 1, i);
                }

                yield return null;
            }
            fadeinisTrue = false;
        }
    }


    public

    // 이미지를 페이드 인/아웃하는 코루틴 메서드
    IEnumerator FadeImageAuto()
    {
 
        for (float i = 0; i <= 3; i += Time.deltaTime)
        {
            //float mappedValue = (originalValue - minValue) / (maxValue - minValue);
            float mappedValue = (i - 0) / (0.5f - 0);
            // i 값을 알파(투명도)로 설정하여 이미지 색상을 변경합니다.
            for (int a = 0; a < img.Count; a++)
            {
                img[a].color = new Color(1, 1, 1, i);
            }
            for (int a = 0; a < text.Count; a++)
            {
                text[a].color = new Color(1, 1, 1, i);
            }
            yield return null;
        }


        yield return new WaitForSeconds(0.5f);

        // 1초 동안 역순으로 반복
        for (float i = 3; i >= 0; i -= Time.deltaTime)
        {
            //float mappedValue = (originalValue - minValue) / (maxValue - minValue);
            float mappedValue = (i - 0) / (0.5f - 0);
            // i 값을 알파(투명도)로 설정하여 이미지 색상을 변경합니다.
            for (int a = 0; a < img.Count; a++)
            {
                img[a].color = new Color(1, 1, 1, i);
            }
            for (int a = 0; a < text.Count; a++)
            {
                text[a].color = new Color(1, 1, 1, i);
            }

            yield return null;
        }
        finished = true;
        yield return null;

    }
}
