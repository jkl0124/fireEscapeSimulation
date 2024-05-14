using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEClickParticleSystem : MonoBehaviour
{
    public ParticleSystem FePs;
    public float maxStartSize = 5f;
    public float maxStartSpeed = 5f;
    public float clickInterval = 0.2f; // Ŭ�� ���� (��)
    public int maxClicksPerInterval = 5; // Ŭ�� ���� �� �ִ� Ŭ�� ��
    public float decreaseRate = 0.1f; // Ŭ���� ������ �� ���� �ӵ�

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

        // Ŭ���� ���߸� ũ��� �ӵ��� ���ҽ�Ŵ
        currentStartSize = Mathf.Max(currentStartSize - decreaseRate * Time.deltaTime, 0f);
        currentStartSpeed = Mathf.Max(currentStartSpeed - decreaseRate * Time.deltaTime, 0f);
        ApplyParticleSettings();
    }

    private void OnMouseDown()
    {
        clickCount++;
        if (clickCount >= maxClicksPerInterval)
        {
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

    private void OnMouseUp()
    {
        clickCount = 0; // Ŭ�� Ƚ�� �ʱ�ȭ
        isClicked = false; // Ŭ�� ���� ����
    }

    private void ApplyParticleSettings()
    {
        // ParticleSystem�� StartSize�� StartSpeed�� ����
        var main = FePs.main;
        main.startSize = currentStartSize;
        main.startSpeed = currentStartSpeed;
    }
}
