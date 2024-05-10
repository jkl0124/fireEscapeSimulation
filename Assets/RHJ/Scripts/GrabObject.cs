using System.Collections;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public Transform Player;
    public bool grabbing;
    public Transform ObjectOnHand_base;
    public Material highlightMaterial;

    [SerializeField] private Material originalMaterial;


    void Start()
    {
        grabbing = false;
        originalMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {

        if (grabbing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("»ç¿ë");
                ItemUse itemUse = GetComponent<ItemUse>();
                if (itemUse != null)
                {
                    itemUse.Use(itemUse.type);
                }

            }

            //if (Input.GetMouseButtonDown(1))
            if (Input.GetKeyDown(KeyCode.E))
            {
                ItemManager.Instance.grabbing_item = null;
                grabbing = false;
                transform.parent = null;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Renderer>().material = originalMaterial;

                // check item need Change Form when it grabbed (ex. towel)
                if (ObjectOnHand_base.tag == "ChangeForm")
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                    ObjectOnHand_base.gameObject.SetActive(false);
                }

            }
        }

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) || Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit) )
        //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
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
            //Debug.Log(dist);
            if (dist < 4 && !grabbing)
            {

                //if (Input.GetMouseButtonDown(0))
                if (Input.GetKeyDown(KeyCode.E))
                {

                    ItemManager.Instance.grabbing_item = gameObject;
                    //Debug.Log(transform.localScale);
                    //Debug.Log("Pushed");
                    transform.parent = ObjectOnHand_base;
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    transform.localPosition = Vector3.zero;
                    grabbing = true;



                    // check item need Change Form when it grabbed (ex. towel)

                    if (ObjectOnHand_base.tag == "ChangeForm")
                    {
                        gameObject.GetComponent<MeshRenderer>().enabled = false;
                        ObjectOnHand_base.gameObject.SetActive(true);
                        return;
                    }

                    transform.rotation = ObjectOnHand_base.rotation;
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
