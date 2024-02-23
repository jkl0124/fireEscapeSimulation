using System.Collections;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public Transform Player;
    public bool grabbing;
    public Transform ObjectOnHand_base;
    public Material highlightMaterial;

    private Material originalMaterial;

    void Start()
    {
        grabbing = false;
        originalMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.transform == transform)
            {
                OnRaycastEnter();
            }
            else
            {
                OnRaycastExit();
            }
        }
        else
        {
            OnRaycastExit();
        }

        if (grabbing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("���");
            }
            if (Input.GetMouseButtonDown(1))
            {
                grabbing = false;
                transform.parent = null;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Renderer>().material = originalMaterial;
            }
        }

    }

    void OnRaycastEnter()
    {
        //Debug.Log("Raycast Enter");
        if (highlightMaterial != null && !grabbing)
        {
            GetComponent<Renderer>().material = highlightMaterial;
        }

        if (Player)
        {
            float dist = Vector3.Distance(Player.position, transform.position);
            Debug.Log(dist);
            if (dist < 4)
            {
                //Debug.Log("Dist < 4");
                if (grabbing == false)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log(transform.localScale);
                        //Debug.Log("Pushed");
                        transform.parent = ObjectOnHand_base;
                        gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        transform.localPosition = Vector3.zero;

                        transform.localRotation = ObjectOnHand_base.localRotation;
                        grabbing = true;
                    }
                }
            }
        }
    }

    void OnRaycastExit()
    {
        //Debug.Log("Raycast Exit");
        GetComponent<Renderer>().material = originalMaterial;
    }
}
