using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEClickParticleSystem : MonoBehaviour
{
    public ParticleSystem FePs;
    public float maxStartSize = 3f;
    public float maxStartSpeed =3f;
    public float clickInterval = 0.2f; // Ŭ�� ���� (��)
    public int maxClicksPerInterval = 5; // Ŭ�� ���� �� �ִ� Ŭ�� ��
    public float decreaseRate = 20f; // Ŭ���� ������ �� ���� �ӵ�

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
                //Debug.Log("���� ����");
                currentStartSize = 0;
                currentStartSpeed = 0;
                ApplyParticleSettings();
                cannotuse = true;
                UseFinishUI.SetActive(true);
                
                return;
            }
            if (isClicked)
                return;

            // Ŭ���� ���߸� ũ��� �ӵ��� ���ҽ�Ŵ
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
            total_usenum++; //���Ƚ�� üũ
            clickCount++;

            if (clickCount >= maxClicksPerInterval)
            {
                clickCount = maxClicksPerInterval;
                // �ִ� Ŭ�� ���� �����ϸ� Ŭ�� ���� ����
                isClicked = true;
            }
            else
            {
                // Ŭ���� �߻��� ������ ũ��� �ӵ��� ������Ŵ
                currentStartSize = Mathf.Min(currentStartSize + decreaseRate, maxStartSize);
                currentStartSpeed = Mathf.Min(currentStartSpeed + decreaseRate, maxStartSpeed);
                ApplyParticleSettings();
            }
        }
    }


    private void ApplyParticleSettings()
    {
        // ParticleSystem�� StartSize�� StartSpeed�� ����
        var main = FePs.main;
        main.startSize = currentStartSize;
        main.startSpeed = currentStartSpeed;
    }

}
