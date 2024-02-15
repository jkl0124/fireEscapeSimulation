using SojaExiles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class BadBehaviourChecker : MonoBehaviour
{


    public opencloseDoor1 opencloseDoor1;
    public ScoreManager scoreManager;
    public GameObject Good_UI;
    public GameObject Bad_UI;

    /*
    void Start()
    {

        if (opencloseDoor1)
        {
            if (opencloseDoor1.open == true)
            {
                Debug.Log("문을 닫지 않았습니다.");
                scoreManager.minus_point += 1;
            }

            else if (opencloseDoor1.open == false)
            {
                Debug.Log("문을 닫았습니다.");
                scoreManager.bonus_point += 1;
            }
        }
        gameObject.SetActive(false);

    }
    */

    // 특정 분기 지점에서 활성화되는 스위치 느낌으로 GoalCheck와 함께 사용

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (opencloseDoor1)
            {
                if (opencloseDoor1.open == true)
                {
                    Debug.Log("문을 닫지 않았습니다.");
                    scoreManager.minus_point += 1;
                    gameObject.SetActive(false);
                }

                else if (opencloseDoor1.open == false)
                {
                    Debug.Log("문을 닫았습니다.");
                    scoreManager.bonus_point += 1;
                    gameObject.SetActive(false);
                }
            }

        }

    }

}
