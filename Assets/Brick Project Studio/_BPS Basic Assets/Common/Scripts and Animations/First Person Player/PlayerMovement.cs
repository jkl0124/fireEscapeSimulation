using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
    public class PlayerMovement : MonoBehaviour
    {

        public float speed = 5f;
        public float turnspeed = 20f;
        public float gravity = -15f;
        public GameObject camera;
        

        public bool interact = false;


        Vector3 velocity;

        // Update is called once per frame
        void Update()
        {



            

            if (Input.GetKey(KeyCode.Z))
            {
                gameObject.transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.C))
            {
                gameObject.transform.position += Vector3.down * speed * Time.deltaTime;
            }

            
            if (Input.GetKey(KeyCode.Q))
            {
                //camera.transform.eulerAngles += new Vector3(0, -10, 0) * turnspeed * Time.deltaTime;
                //transform.eulerAngles = new Vector3(0, camera.transform.eulerAngles.y, 0);
                transform.eulerAngles += new Vector3(0, -10, 0) * turnspeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.E))
            {
                //camera.transform.eulerAngles += new Vector3(0, 10, 0) * turnspeed * Time.deltaTime;
                //transform.eulerAngles = new Vector3(0, camera.transform.eulerAngles.y, 0);
                transform.eulerAngles += new Vector3(0, 10, 0) * turnspeed * Time.deltaTime;
            }
            

            //transform.eulerAngles = new Vector3(0, camera.transform.localEulerAngles.y, 0);


            if (Input.GetKeyDown(KeyCode.Space) && !interact)
            {
                interact = false;
                Debug.Log("button pushed");
            }

        }
        void FixedUpdate()
        {

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 position = new Vector3(z, 0, -x) * speed * Time.deltaTime;
            transform.Translate(position, Space.Self);






        }
    }
}