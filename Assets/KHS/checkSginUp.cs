using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class checkSginUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popup;
    // public Button refuse;
    void Start()
    {

    }


    // Update is called once per frame  
    void Update()
    {
        
    }

    // public void active(){
    //     popup.gameObject.SetActive(true);
    // }

    public void oncheck(){
           popup.gameObject.SetActive(false);
           SceneManager.LoadScene("LOGIN");
    }
}
