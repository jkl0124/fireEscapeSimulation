using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDistanceMGR : MonoBehaviour
{
    public GameObject palm;
    public bool Fireheat;
    
    void Start()
    {
        palm.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(palm.transform.position, transform.position);

        if (distance < 2)
        {
            palm.SetActive(true);
            //Debug.Log(distance);
        }

        else if (distance >= 2)
        {
            CollisionInput input = palm.GetComponent<CollisionInput>();
            input.temp = -0;
            palm.SetActive(false);
            //Debug.Log(distance);
        }
    }
}
