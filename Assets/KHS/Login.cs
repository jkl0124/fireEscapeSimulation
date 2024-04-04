using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase.Auth;
using Firebase.Extensions;
public class Login : MonoBehaviour
{
    [SerializeField] InputField emailField;
    [SerializeField] InputField passwordField;
        Firebase.Auth.FirebaseAuth auth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

void Awake(){
    auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLogin(){
        auth.SignInWithEmailAndPasswordAsync(emailField.text, passwordField.text).ContinueWith(task => {
  if (task.IsCanceled) {
    Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
    return;
  }
  if (task.IsFaulted) {
    Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
    return;
  }

  Firebase.Auth.AuthResult result = task.Result;
  Debug.LogFormat("User signed in successfully: {0} ({1})",
      result.User.DisplayName, result.User.UserId);
});

    }

    public void onSingup(){
        SceneManager.LoadScene("SIGNUP");
    } 
}
