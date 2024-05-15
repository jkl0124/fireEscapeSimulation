using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;


public class DBRepository : MonoBehaviour
{
    // public static DBRepository Instance = null;

    private static DBRepository _instance;
    public static DBRepository Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DBRepository>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("DBRepository");
                    _instance = go.AddComponent<DBRepository>();
                }
            }
            return _instance;
        }
    }

    DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
    string loginUserID;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {
        // if (Instance == null)
        // {
        //     Instance = new DBRepository();
        // }
        // else if (Instance != this)
        // {
        //     Destory(Instance);
        // }
        // Instance = this;
        // UnityEngine.Object.DontDestoryOnLoad(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void checkTitle()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Title").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            { // 성공적으로 데이터를 가져왔으면
                DataSnapshot snapshot = task.Result;
                // 데이터를 출력하고자 할때는 Snapshot 객체 사용함
                Debug.Log(snapshot);
                foreach (DataSnapshot data in snapshot.Children)
                {
                    IDictionary rank = (IDictionary)data.Value;
                    Debug.Log("이름: " + rank["userEmail"] + ", 점수: " + rank["fireExtinguisher"]);
                    // JSON은 사전 형태이기 때문에 딕셔너리 형으로 변환
                }
            }
        });
    }

    public void loginTitleDB(string userId)
    {
        this.loginUserID = userId;
        FirebaseDatabase.DefaultInstance.GetReference("Title").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Debug.Log(userId);
                // 데이터를 출력하고자 할때는 Snapshot 객체 사용함
                foreach (DataSnapshot data in snapshot.Children)
                {
                    if (userId == data.Key)
                    {
                        IDictionary rank = (IDictionary)data.Value;
                        TitleSingleManager.Instance.setTitle((long)rank["FE_first_use"], (long)rank["T_Fire_fighter"], (long)rank["FE_use"], (long)rank["FE_all_use"], (long)rank["first_bucket"], (long)rank["bucket_success"], (long)rank["handkerchief_use"], (long)rank["swift_evacuation"], (long)rank["safe_evacuation"], (long)rank["FITMOS"]);
                    }

                }
            }
        });
    }

    public void saveDB()
    {
        string json = JsonUtility.ToJson(TitleSingleManager.Instance);
        Debug.Log(json);
        reference.Child("Title").Child(loginUserID).SetRawJsonValueAsync(json);
    }

    public void logoutTitleDB()
    {
        loginUserID = null;
        TitleSingleManager.Instance.setTitle(0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    }


    //계정 만들때 DB생성
    public void signupDBTile(string userId)
    {
        string json = JsonUtility.ToJson(TitleSingleManager.Instance);
        Debug.Log(json);
        reference.Child("Title").Child(userId).SetRawJsonValueAsync(json);
    }
}
