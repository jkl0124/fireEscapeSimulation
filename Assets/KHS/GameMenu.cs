using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase.Database;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMenu: MonoBehaviour
{
    [SerializeField] Button LoginButton;
    [SerializeField] Button LogoutButton;
    // Start is called before the first frame update
    Firebase.Auth.FirebaseUser user;
    Firebase.Auth.FirebaseAuth auth;
     
    
    void Start()
    {
  
            auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        user = auth.CurrentUser;
        
         if (user != null) {
                   LoginButton.gameObject.SetActive(false);
            foreach (var profile in user.ProviderData) {
              // Id of the provider (ex: google.com)
           string  providerId = profile.ProviderId;
            string uid = profile.UserId;
             Debug.Log(uid);
                 string name = profile.DisplayName;
        string email = profile.Email;

        Debug.Log(providerId);
            Debug.Log(name);
                Debug.Log(email);
    
       
  }
    }
    else{

          LogoutButton.gameObject.SetActive(false);
    }
    }
    // Update is called once per frame
    void Update()
    {}
    public void goLogin(){
      SceneManager.LoadScene("Login");
    }

    public void onLogout(){
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
      auth.SignOut();
      LoginButton.gameObject.SetActive(true);
      LogoutButton.gameObject.SetActive(false);
    }

    public void goTitle(){
      SceneManager.LoadScene("title");
    }
    public void goGame(){
      SceneManager.LoadScene("temp");
    }

}