using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public Text timerText;
    public float countdownTime = 10.9f; // 초 단위로 카운트 다운 시간 설정
    private float currentTime;
    public int prevtime;
    public int num = 10;
    public List<GameObject> timerimg;


    void Start()
    {
        // 초기 시간 설정
        currentTime = countdownTime;
        UpdateTimerText();
    }

    void Update()
    {

        // 현재 시간을 감소시킴
        currentTime -= Time.deltaTime;
        prevtime = (int)currentTime;

        // 현재 시간이 0 이하로 떨어지지 않도록 보정
        if (currentTime < 0f)
        {
            currentTime = 0f;
        }

        // 타이머 텍스트 업데이트
        UpdateTimerText();

        // 타이머가 0에 도달하면 원하는 작업을 수행하거나 타이머를 멈출 수 있음
        if (currentTime <= 0f)
        {
            // 여기에 타이머가 0에 도달했을 때 수행할 작업을 추가하세요.
        }
    }

    void UpdateTimerText()
    {
        // 현재 시간을 문자열로 변환하여 텍스트 업데이트

        if (prevtime < num)
        {
            //timerText.text = currentTime.ToString("0") + "초";
            timerText.text = prevtime.ToString("0") + "초";
            timerimg[num - 1].SetActive(false);
            num = prevtime;
        }

    }
}
