using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCheck : MonoBehaviour
{

    [SerializeField] GameObject TargetEvent;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("�溸");
            TargetEvent.SetActive(true);
        }

    }
}
