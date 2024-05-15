using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
public class AuthManager : MonoBehaviour
{
    Firebase.Auth.FirebaseAuth auth;

     private static AuthManager _instance;
    public static AuthManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AuthManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("AuthManager");
                    _instance = go.AddComponent<AuthManager>();
                }
            }
            return _instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
