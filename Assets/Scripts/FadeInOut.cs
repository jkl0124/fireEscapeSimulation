using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class FadeInOut : MonoBehaviour

{
    public GameObject window;
    public float animTime = 10f;         // Fade �ִϸ��̼� ��� �ð� (����:��).  
    public Image fadeImage;            // UGUI�� Image������Ʈ ���� ����.  
    public Color textcolor;


    private float start = 0.7f;           // Mathf.Lerp �޼ҵ��� ù��° ��.  
    private float end = 0f;             // Mathf.Lerp �޼ҵ��� �ι�° ��.  
    private float time = 0f;            // Mathf.Lerp �޼ҵ��� �ð� ��.  


    public bool stopIn = false;
    public bool stopOut = true;

    public bool endpoint = false;




    void Awake()
    {
        // Image ������Ʈ�� �˻��ؼ� ���� ���� �� ����.  
        //fadeImage = GetComponent<Image>();

    }

    void Start()
    {

    }

    void Update()
    {

        // ���������� = FadeIn �ִϸ��̼� ���.

        if (stopIn == true && time <= 5)
        {
            PlayFadeIn();
        }
        // �������� = Fadeout �ִϸ��̼� ���
        if (stopOut == true && time <= 5)
        {
            PlayFadeOut();
        }
        /*if(time>=2 && stopIn==true){
            stopIn = false;
            time = 0;                
            Debug.Log("StopIn");
            endpoint = true;
        }*/
        if (time >= 5 && stopOut == true)
        {
            stopIn = true;
            stopOut = false;
            time = 0;
            Debug.Log("StopOut");
        }


    }

    // ���->����
    void PlayFadeIn()
    {

        // ��� �ð� ���.  
        // 2��(animTime)���� ����� �� �ֵ��� animTime���� ������.  
        time += Time.deltaTime / animTime;

        // Image ������Ʈ�� ���� �� �о����.  
        Color color = fadeImage.color;
        // ���� �� ���.  
        color.a = Mathf.Lerp(start, end, time);
        // ����� ���� �� �ٽ� ����.  
        fadeImage.color = color;
        // Debug.Log(time);
        if (color.a == 0)
        {
            stopIn = false;
            time = 0;
            Debug.Log("StopIn");
            window.SetActive(false);
        }
    }

    // ����->���
    void PlayFadeOut()
    {
        // ��� �ð� ���.  
        // 2��(animTime)���� ����� �� �ֵ��� animTime���� ������.  
        time += Time.deltaTime / animTime;

        // Image ������Ʈ�� ���� �� �о����.  
        Color color = fadeImage.color;
        // ���� �� ���.  
        color.a = Mathf.Lerp(end, start, time);  //FadeIn���� �޸� start, end�� �ݴ��.
        // ����� ���� �� �ٽ� ����.  
        fadeImage.color = color;
    }

}