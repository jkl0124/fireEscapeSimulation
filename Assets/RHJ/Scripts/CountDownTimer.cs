using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public Text timerText;
    public float countdownTime = 10.9f; // �� ������ ī��Ʈ �ٿ� �ð� ����
    private float currentTime;
    public int prevtime;
    public int num = 10;
    public List<GameObject> timerimg;


    private void OnEnable()
    {
        // �ʱ� �ð� ����
        currentTime = countdownTime;
        prevtime = 10;
        num = 10;
        timerText.text = "10��";
        UpdateTimerText();
    }

    void Update()
    {

        // ���� �ð��� ���ҽ�Ŵ
        currentTime -= Time.deltaTime;
        prevtime = (int)currentTime;

        // ���� �ð��� 0 ���Ϸ� �������� �ʵ��� ����
        if (currentTime < 0f)
        {
            currentTime = 0f;
        }

        // Ÿ�̸� �ؽ�Ʈ ������Ʈ
        UpdateTimerText();

        // Ÿ�̸Ӱ� 0�� �����ϸ� ���ϴ� �۾��� �����ϰų� Ÿ�̸Ӹ� ���� �� ����
        if (currentTime <= 0f)
        {
            // ���⿡ Ÿ�̸Ӱ� 0�� �������� �� ������ �۾��� �߰��ϼ���.
        }
    }

    void UpdateTimerText()
    {
        // ���� �ð��� ���ڿ��� ��ȯ�Ͽ� �ؽ�Ʈ ������Ʈ

        if (prevtime < num)
        {
            //timerText.text = currentTime.ToString("0") + "��";
            timerText.text = prevtime.ToString("0") + "��";
            timerimg[num - 1].SetActive(false);
            num = prevtime;
        }

    }
}
