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
                Debug.Log("���� ���� �ʾҽ��ϴ�.");
                scoreManager.minus_point += 1;
            }

            else if (opencloseDoor1.open == false)
            {
                Debug.Log("���� �ݾҽ��ϴ�.");
                scoreManager.bonus_point += 1;
            }
        }
        gameObject.SetActive(false);

    }
    */

    // Ư�� �б� �������� Ȱ��ȭ�Ǵ� ����ġ �������� GoalCheck�� �Բ� ���

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (opencloseDoor1)
            {
                if (opencloseDoor1.open == true)
                {
                    Debug.Log("���� ���� �ʾҽ��ϴ�.");
                    scoreManager.minus_point += 1;
                    gameObject.SetActive(false);
                }

                else if (opencloseDoor1.open == false)
                {
                    Debug.Log("���� �ݾҽ��ϴ�.");
                    scoreManager.bonus_point += 1;
                    gameObject.SetActive(false);
                }
            }

        }

    }

}
