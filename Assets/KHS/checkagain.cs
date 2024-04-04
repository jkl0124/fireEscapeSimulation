using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkagain : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popup2;
    // public Button check;
    void Start()
    {

    }

    // Update is called once per frame
    public void onaccept(){
        popup2.gameObject.SetActive(false);
    }
}
