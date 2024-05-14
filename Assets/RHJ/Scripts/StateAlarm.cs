using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAlarm : MonoBehaviour
{
    public float alerttime = 10f; // �� �ð��� �������� �˸� ����
    public float timepasscheck;

    public float gasamount = 1; //gas�� ��
    public float oxygenamount = 1; //oxygen ���ҷ�

    private int alertcount = 0;

    private static StateAlarm _Instance;
    public static StateAlarm Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindAnyObjectByType<StateAlarm>();
            }
            return _Instance;
        }
    }

    void Update()
    {
        timepasscheck += Time.deltaTime;
        if (timepasscheck > alerttime)
        {
            UpdateState();
            timepasscheck = 0;
            alertcount++;
        }
        if (alertcount >= 10)
        {
            StateManager.Instance.UpdateHp(Random.Range(-4, -1));
            alertcount = 0;
        }
    }

    public void UpdateState()
    {
        StateManager.Instance.UpdateOxygen(-oxygenamount);
        StateManager.Instance.UpdateGas(gasamount);
    }

    // alerttime ����
    public void SetAlertTime(float time)
    {
        alerttime = time;
    }
    //oxygen �� ����
    public void SetOxygenAmount(float value)
    {
        oxygenamount = value;
    }
    // gas �� ����
    public void SetGasAmount(float value)
    {
        gasamount = value;
    }
  
}
