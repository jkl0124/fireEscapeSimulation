using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ImageFade : MonoBehaviour
{
    // ���̵� ��/�ƿ��� �̹���, �ν�����(Inspector)���� �Ҵ�
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
                StartCoroutine(FadeImage(fadeinisTrue));//fadeinisTrue�� true�� ���̵��� ȣ��, false�� ���̵�ƿ� ȣ��
        }
        if (finished)
            Destroy(fordestroy);
    }
    /*
    // ��ư Ŭ���� ȣ��� �޼���
    public void OnButtonClick()
    {
        // Ŭ�� �� �̹����� ���̵� �ƿ�(�������)�մϴ�.
        StartCoroutine(FadeImage(true));
    }
    */


    public 

    // �̹����� ���̵� ��/�ƿ��ϴ� �ڷ�ƾ �޼���
    IEnumerator FadeImage(bool fadeAway)
    {
        // ������ -> ����
        if (!fadeAway)
        {
            // 1�� ���� �������� �ݺ�
            for (float i = 3; i >= 0; i -= Time.deltaTime)
            {
                //float mappedValue = (originalValue - minValue) / (maxValue - minValue);
                float mappedValue = (i - 0) / (0.5f - 0);
                // i ���� ����(����)�� �����Ͽ� �̹��� ������ �����մϴ�.
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
        // ���� -> ������
        else
        {
            
            // 1�� ���� �ݺ�
            for (float i = 0; i <= 3; i += Time.deltaTime)
            {
                //float mappedValue = (originalValue - minValue) / (maxValue - minValue);
                float mappedValue = (i - 0) / (0.5f - 0);
                // i ���� ����(����)�� �����Ͽ� �̹��� ������ �����մϴ�.
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

    // �̹����� ���̵� ��/�ƿ��ϴ� �ڷ�ƾ �޼���
    IEnumerator FadeImageAuto()
    {
 
        for (float i = 0; i <= 3; i += Time.deltaTime)
        {
            //float mappedValue = (originalValue - minValue) / (maxValue - minValue);
            float mappedValue = (i - 0) / (0.5f - 0);
            // i ���� ����(����)�� �����Ͽ� �̹��� ������ �����մϴ�.
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

        // 1�� ���� �������� �ݺ�
        for (float i = 3; i >= 0; i -= Time.deltaTime)
        {
            //float mappedValue = (originalValue - minValue) / (maxValue - minValue);
            float mappedValue = (i - 0) / (0.5f - 0);
            // i ���� ����(����)�� �����Ͽ� �̹��� ������ �����մϴ�.
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
