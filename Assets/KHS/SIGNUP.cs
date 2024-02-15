using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase.Extensions;
using System.Threading;
public class SGINUP : MonoBehaviour
{

    [SerializeField] InputField emailField;
    [SerializeField] InputField passField;
    [SerializeField] InputField CHECK;
    // Start is called before the first frame update
    public GameObject popup;
    public GameObject popup2;
    public GameObject verifyPassword;
    Firebase.Auth.FirebaseAuth auth;
    public GameObject UnityMainThreadDispatcher;
    private Queue<string> qq = new Queue<string>();
    void Start()
    {

    }

    void Awake()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        // if(_instance == null){
        //     DontDestroyOnLoad(gameObject);
        //     var dependencyResult = await FirebaseApp.Check
        // }
        popup.gameObject.SetActive(false);
        popup2.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CHECK.text == passField.text)
        {
            verifyPassword.SetActive(false);
        }
        else
        {
            verifyPassword.SetActive(true);
        }

        if(qq.Count > 0){
            string sstemp = qq.Dequeue();
            if(sstemp=="회원가입"){
                onpopup();
                
            }
            else{
                onpopup2();
            }
        }
    }

    public void onbutton()
    {
        auth.CreateUserWithEmailAndPasswordAsync(emailField.text, passField.text).ContinueWith(
        task =>
        {
            if (!task.IsCanceled && !task.IsFaulted && CHECK.text == passField.text)
            {

                Debug.Log(emailField.text + "로 회원가입\n");
                qq.Enqueue("회원가입");
            }
            else
            {
                Debug.Log("회원가입 실패\n");
                qq.Enqueue("회원가입 실패");
            }
        });
    }

    void onpopup(){
        popup.gameObject.SetActive(true);
    }

    void onpopup2(){
        popup2.gameObject.SetActive(true);
    }
}