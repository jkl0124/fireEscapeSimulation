using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEClickParticleSystem : MonoBehaviour
{
    public ParticleSystem FePs;
    public float maxStartSize = 3f;
    public float maxStartSpeed =3f;
    public float clickInterval = 0.2f; // 클릭 간격 (초)
    public int maxClicksPerInterval = 5; // 클릭 간격 내 최대 클릭 수
    public float decreaseRate = 20f; // 클릭이 멈췄을 때 감소 속도

    private int clickCount = 0;
    private float currentStartSize;
    private float currentStartSpeed;
    private bool isClicked = false;

    private int total_usenum = 0;
    private int max_usenum = 80;

    [SerializeField] GameObject UseFinishUI;
    public bool cannotuse = false;

    private void Start()
    {
        currentStartSize = FePs.main.startSize.constant;
        currentStartSpeed = FePs.main.startSpeed.constant;
    }

    private void Update()
    {
        if (!cannotuse)
        {

            if (total_usenum >= max_usenum)
            {
                //Debug.Log("이제 못씀");
                currentStartSize = 0;
                currentStartSpeed = 0;
                ApplyParticleSettings();
                cannotuse = true;
                UseFinishUI.SetActive(true);
                
                return;
            }
            if (isClicked)
                return;

            // 클릭이 멈추면 크기와 속도를 감소시킴
            currentStartSize = Mathf.Max(currentStartSize - decreaseRate * Time.deltaTime, 0f);
            currentStartSpeed = Mathf.Max(currentStartSpeed - decreaseRate * Time.deltaTime, 0f);
            clickCount--;
            ApplyParticleSettings();
        }
    }
   


    public void UsingFE()
    {
        if (!cannotuse)
        {
            total_usenum++; //사용횟수 체크
            clickCount++;

            if (clickCount >= maxClicksPerInterval)
            {
                clickCount = maxClicksPerInterval;
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
    }


    private void ApplyParticleSettings()
    {
        // ParticleSystem의 StartSize와 StartSpeed를 설정
        var main = FePs.main;
        main.startSize = currentStartSize;
        main.startSpeed = currentStartSpeed;
    }

}
