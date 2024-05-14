using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAlarm : MonoBehaviour
{
    public float alerttime = 10f; // 이 시간을 기준으로 알림 보냄
    public float timepasscheck;

    public float gasamount = 1; //gas의 양
    public float oxygenamount = 1; //oxygen 감소량

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

    // alerttime 설정
    public void SetAlertTime(float time)
    {
        alerttime = time;
    }
    //oxygen 양 설정
    public void SetOxygenAmount(float value)
    {
        oxygenamount = value;
    }
    // gas 양 설정
    public void SetGasAmount(float value)
    {
        gasamount = value;
    }
  
}
