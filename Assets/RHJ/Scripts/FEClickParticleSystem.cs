using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEClickParticleSystem : MonoBehaviour
{
    public ParticleSystem FePs;
    public float maxStartSize = 5f;
    public float maxStartSpeed = 5f;
    public float clickInterval = 0.2f; // 클릭 간격 (초)
    public int maxClicksPerInterval = 5; // 클릭 간격 내 최대 클릭 수
    public float decreaseRate = 0.1f; // 클릭이 멈췄을 때 감소 속도

    private int clickCount = 0;
    private float currentStartSize;
    private float currentStartSpeed;
    private bool isClicked = false;

    private void Start()
    {
        currentStartSize = FePs.main.startSize.constant;
        currentStartSpeed = FePs.main.startSpeed.constant;
    }

    private void Update()
    {
        if (isClicked)
            return;

        // 클릭이 멈추면 크기와 속도를 감소시킴
        currentStartSize = Mathf.Max(currentStartSize - decreaseRate * Time.deltaTime, 0f);
        currentStartSpeed = Mathf.Max(currentStartSpeed - decreaseRate * Time.deltaTime, 0f);
        ApplyParticleSettings();
    }

    private void OnMouseDown()
    {
        clickCount++;
        if (clickCount >= maxClicksPerInterval)
        {
            // 최대 클릭 수에 도달하면 클릭 상태 유지
            isClicked = true;
        }
        else
        {
            // 클릭이 발생할 때마다 크기와 속도를 증가시킴
            currentStartSize = Mathf.Min(currentStartSize + decreaseRate, maxStartSize);
            currentStartSpeed = Mathf.Min(currentStartSpeed + decreaseRate, maxStartSpeed);
            ApplyParticleSettings();
        }
    }

    private void OnMouseUp()
    {
        clickCount = 0; // 클릭 횟수 초기화
        isClicked = false; // 클릭 상태 해제
    }

    private void ApplyParticleSettings()
    {
        // ParticleSystem의 StartSize와 StartSpeed를 설정
        var main = FePs.main;
        main.startSize = currentStartSize;
        main.startSpeed = currentStartSpeed;
    }
}
