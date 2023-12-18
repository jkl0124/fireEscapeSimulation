using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveinput : MonoBehaviour
{
    public static int state;
    public static float speed = 3.5f;
 
    public GameObject OVRCamera;
    public GameObject cube;
    public Vector3 a;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
 
        state = 0;
        OVRCamera = GameObject.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");
        if (cube != null) a = cube.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     
        var translation = GetInputTranslationDirection2().normalized * Time.deltaTime;
        gameObject.transform.Translate(speed * translation);

        var translation2 = GetInputTranslationDirection3().normalized * Time.deltaTime;
        player.transform.Translate(speed * translation2);

        // Framerate-independent interpolation
        // Calculate the lerp amount, such that we get 99% of the way to our target in the specified time
        if (state == 0)
        {
            return;
        }

        else if (state == 1)
        {
            Vector3 direction = new Vector3();
            direction += OVRCamera.transform.forward;
            direction = new Vector3(direction.x, 0, direction.z);
            gameObject.transform.Translate(0.4f * speed * direction.normalized * Time.deltaTime);
        }

        else if (state == 2)
        {
            Vector3 direction = new Vector3();
            direction += OVRCamera.transform.forward;
            direction = new Vector3(direction.x, 0, direction.z);
            gameObject.transform.Translate(1.0f * speed * direction.normalized * Time.deltaTime);
        }

        else if (state == 3)
        {
            Vector3 direction = new Vector3();
            direction += OVRCamera.transform.forward;
            direction = new Vector3(direction.x, 0, direction.z);
            gameObject.transform.Translate(2.0f * speed * direction.normalized * Time.deltaTime);
        }
        gameObject.transform.Translate(speed * translation);
        if (Input.GetKey(KeyCode.R) && cube != null)
        {
            cube.transform.position = a;
            cube.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            cube.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.C))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + speed * Time.deltaTime * 15, transform.eulerAngles.z);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - speed * Time.deltaTime * 15, transform.eulerAngles.z);
        }
    }


    Vector3 GetInputTranslationDirection2()
    {
        Vector3 direction = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            direction += OVRCamera.transform.forward;
            direction = new Vector3(direction.x, 0, direction.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += OVRCamera.transform.forward * -1f;
            direction = new Vector3(direction.x, 0, direction.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += OVRCamera.transform.right * -1f;
            direction = new Vector3(direction.x, 0, direction.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += OVRCamera.transform.right;
            direction = new Vector3(direction.x, 0, direction.z);
        }

        /*
        if (Input.GetKey(KeyCode.Q))
        {
            direction += OVRCamera.transform.up * -1f;
            direction = new Vector3(0, direction.y, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            direction += OVRCamera.transform.up;
            direction = new Vector3(0, direction.y, 0);
        }
        */

        return direction;
    }

    Vector3 GetInputTranslationDirection3()
    {
        Vector3 direction = new Vector3();

        if (Input.GetKey(KeyCode.R))
        {
            cube.transform.position = a;
            cube.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            cube.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            direction += OVRCamera.transform.up * -1f;
            direction = new Vector3(0, direction.y, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            direction += OVRCamera.transform.up;
            direction = new Vector3(0, direction.y, 0);
        }

        return direction;
    }


}