using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class FadeInOut : MonoBehaviour

{
    public GameObject window;
    public float animTime = 10f;         // Fade 애니메이션 재생 시간 (단위:초).  
    public Image fadeImage;            // UGUI의 Image컴포넌트 참조 변수.  
    public Color textcolor;


    private float start = 0.7f;           // Mathf.Lerp 메소드의 첫번째 값.  
    private float end = 0f;             // Mathf.Lerp 메소드의 두번째 값.  
    private float time = 0f;            // Mathf.Lerp 메소드의 시간 값.  


    public bool stopIn = false;
    public bool stopOut = true;

    public bool endpoint = false;




    void Awake()
    {
        // Image 컴포넌트를 검색해서 참조 변수 값 설정.  
        //fadeImage = GetComponent<Image>();

    }

    void Start()
    {

    }

    void Update()
    {

        // 투명해지는 = FadeIn 애니메이션 재생.

        if (stopIn == true && time <= 5)
        {
            PlayFadeIn();
        }
        // 진해지는 = Fadeout 애니메이션 재생
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

    // 흰색->투명
    void PlayFadeIn()
    {

        // 경과 시간 계산.  
        // 2초(animTime)동안 재생될 수 있도록 animTime으로 나누기.  
        time += Time.deltaTime / animTime;

        // Image 컴포넌트의 색상 값 읽어오기.  
        Color color = fadeImage.color;
        // 알파 값 계산.  
        color.a = Mathf.Lerp(start, end, time);
        // 계산한 알파 값 다시 설정.  
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

    // 투명->흰색
    void PlayFadeOut()
    {
        // 경과 시간 계산.  
        // 2초(animTime)동안 재생될 수 있도록 animTime으로 나누기.  
        time += Time.deltaTime / animTime;

        // Image 컴포넌트의 색상 값 읽어오기.  
        Color color = fadeImage.color;
        // 알파 값 계산.  
        color.a = Mathf.Lerp(end, start, time);  //FadeIn과는 달리 start, end가 반대다.
        // 계산한 알파 값 다시 설정.  
        fadeImage.color = color;
    }

}