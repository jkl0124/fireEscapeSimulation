using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheckMGR : MonoBehaviour
{
    public float temp_value;
    public int temp_index;
    public string leftorright;
    public Udpnetwork udpnetwork;

    public bool Fireheat;
    public bool send = false;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    
    void OnTriggerStay(Collider triggerCollider)
    {
        if (triggerCollider.tag == "tempObj")
        {
            var tempinput = triggerCollider.gameObject.GetComponent<CollisionInput>();
            temp_value = tempinput.temp;
            string msg = leftorright + "," + temp_index.ToString() + "," + temp_value.ToString();
            udpnetwork.Sendmsg(msg);
            
            Debug.Log(msg);

            if (temp_value <= 0)
            {
                renderer.material.color = Color.blue;
            }
            else if (temp_value > 0)
            {
                renderer.material.color = Color.red;
            }
        }

        
    }
    
    void OnTriggerExit(Collider triggerCollider)
    {
        if (triggerCollider.tag == "tempObj")
        {
            string msg = temp_index.ToString() + "," + 0;
            udpnetwork.Sendmsg(msg);
            Debug.Log(temp_index.ToString() + "exit");

            renderer.material.color = Color.white;
        }
        
    }
    
}
