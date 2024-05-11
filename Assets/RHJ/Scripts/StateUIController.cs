using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StateUIController : MonoBehaviour
{
    public GameObject stateWindow;
    private bool isStateWindowOpen = false;

    private float startTime; //화재 발생 시간
    private float elapsedTime; //화재 발생 후부터 경과 시간


    [SerializeField] TMP_Text elapsedTimetext;
    [SerializeField] TMP_Text hp_state;
    [SerializeField] TMP_Text oxygen_state;
    [SerializeField] TMP_Text gas_state;
    [SerializeField] Image hp_bar;
    [SerializeField] Image ox_bar;
    [SerializeField] Image gas_bar;


    private void OnEnable()
    {
        startTime = Time.time;
    }

        private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleStateWindow();
        }
        if (isStateWindowOpen)
        {
            elapsedTime = Time.time - startTime;
            elapsedTimetext.text = elapsedTime.ToString("F2") + " 초";

            float hp = StateManager.Instance.ReturnHP();
            float oxygen = StateManager.Instance.ReturnOxygen();
            float gas = StateManager.Instance.ReturnGas();

            hp_state.text = "체력    " + hp.ToString() + "%";
            oxygen_state.text = "산소    " + oxygen.ToString() + "%";
            gas_state.text = "유독가스    " + gas.ToString() + "%";

            hp_bar.fillAmount = (float)hp * 0.01f;
            ox_bar.fillAmount = (float)oxygen * 0.01f;
            gas_bar.fillAmount = (float)gas * 0.01f;
        }
        
    }

    private void ToggleStateWindow()
    {
        isStateWindowOpen = !isStateWindowOpen;
        stateWindow.SetActive(isStateWindowOpen);
    }

    public float ReturnElapsedTime()
    {
        return elapsedTime;
    }

}
