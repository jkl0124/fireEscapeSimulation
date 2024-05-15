using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.EventSystems;

public class SGINUP : MonoBehaviour
{
    EventSystem system;
    [SerializeField] InputField emailField;
    [SerializeField] InputField passField;
    [SerializeField] InputField CHECK;
    [SerializeField] Button SignupButton;
    // Start is called before the first frame update
    public GameObject popup;
    public GameObject verifyPassword;
    Firebase.Auth.FirebaseAuth auth;
    private GameObject UnityMainThreadDispatcher;
    private Queue<string> qq = new Queue<string>();
    void Start()
    {
        system = EventSystem.current;
        emailField.Select();
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    void Awake()
    {
        // if(_instance == null){
        //     DontDestroyOnLoad(gameObject);
        //     var dependencyResult = await FirebaseApp.Check
        // }
        popup.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if (CHECK.text == passField.text)
        // {
        //     verifyPassword.SetActive(false);
        // }
        // else
        // {
        //     //onsignup button off
        //     verifyPassword.SetActive(true);
        // }

        if (qq.Count > 0)
        {
            string sstemp = qq.Dequeue();
            if (sstemp == "회원가입실패")
            {
                onpopup();
            }
            else
            {
                DBRepository.Instance.signupDBTile(sstemp);
                SceneManager.LoadScene("Login");
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
            SignupButton.onClick.Invoke();
        }
    }

    public void onSingup()
    {
        auth.CreateUserWithEmailAndPasswordAsync(emailField.text, passField.text).ContinueWith(
        task =>
        {
            if (!task.IsCanceled && !task.IsFaulted && CHECK.text == passField.text)
            {
                Debug.Log(task.Result.User.UserId);
                Debug.Log(emailField.text + "로 회원가입\n");

                qq.Enqueue(task.Result.User.UserId);
            }
            else
            {
                Debug.Log("회원가입 실패\n");
                qq.Enqueue("회원가입 실패");
            }
        });
    }

    void onpopup()
    {
        popup.gameObject.SetActive(true);
    }

    public void loadLogin()
    {
        SceneManager.LoadScene("Login");
    }
}