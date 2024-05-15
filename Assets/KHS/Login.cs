using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine.EventSystems;
public class Login : MonoBehaviour
{

    // private static Login _instance;
    // public static Login Instance
    // {
    //     get
    //     {
    //         if (_instance == null)
    //         {
    //             _instance = FindObjectOfType<Login>();
    //             if (_instance == null)
    //             {
    //                 GameObject go = new GameObject("Login");
    //                 _instance = go.AddComponent<Login>();
    //             }
    //         }
    //         return _instance;
    //     }
    // }

    EventSystem system;
    [SerializeField] InputField emailField;
    [SerializeField] InputField passwordField;
    Firebase.Auth.FirebaseAuth auth;
    // Start is called before the first frame update
    [SerializeField] Button LoginButton;
    private Queue<string> qq = new Queue<string>();
    public GameObject popup;

    void Start()
    {
        system = EventSystem.current;
        emailField.Select();
    }

    void Awake()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        popup.gameObject.SetActive(false);
    }

    void onpopup()
    {
        popup.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (qq.Count > 0)
        {
            string sstemp = qq.Dequeue();
            if (sstemp == "로그인실패")
            {
                onpopup();
            }
            else
            {
                DBRepository.Instance.loginTitleDB(sstemp);
                SceneManager.LoadScene("testDB");
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            // Tab + LeftShift는 위의 Selectable 객체를 선택
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if (next != null)
            {
                next.Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Tab은 아래의 Selectable 객체를 선택
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null)
            {
                next.Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            // 엔터키를 치면 로그인 (제출) 버튼을 클릭
            LoginButton.onClick.Invoke();
            Debug.Log("Button pressed!");
        }
    }

    public void OnLogin()
    {
        auth.SignInWithEmailAndPasswordAsync(emailField.text, passwordField.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.Log("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                Debug.Log(task);
                qq.Enqueue("로그인실패");
                return;
            }
            Firebase.Auth.AuthResult result = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
            result.User.DisplayName, result.User.UserId);
            // qq.Enqueue("로그인성공");
            qq.Enqueue(result.User.UserId);
            SceneManager.LoadScene("GameMenu");
        });
    }

    public void onSingup()
    {
        SceneManager.LoadScene("SIGNUP");
    }

    public void offpopup()
    {
        popup.gameObject.SetActive(false);
    }
}
