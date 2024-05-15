using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;

public class TitleScript : MonoBehaviour
{


     DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {   

                reference.GetValueAsync().ContinueWith(task =>{ if (task.IsCompleted){ // 성공적으로 데이터를 가져왔으면
                DataSnapshot snapshot = task.Result;
                // 데이터를 출력하고자 할때는 Snapshot 객체 사용함
                Debug.Log(snapshot);
                foreach(DataSnapshot data in snapshot.Children){
                    IDictionary rank = (IDictionary)data.Value;
                    Debug.Log("이름: " + rank["userEmail"] + ", 점수: " + rank["userName"]);
                    // JSON은 사전 형태이기 때문에 딕셔너리 형으로 변환
                }
            }});
    }

    public void checkData(){
        reference.GetValueAsync().ContinueWith(task =>{ if (task.IsCompleted){ // 성공적으로 데이터를 가져왔으면
                DataSnapshot snapshot = task.Result;
                Debug.Log(snapshot);
                foreach(DataSnapshot data in snapshot.Children){
                    IDictionary rank = (IDictionary)data.Value;
                    Debug.Log("이름: " + rank["userEmail"] + ", 점수: " + rank["userName"]);
                    // JSON은 사전 형태이기 때문에 딕셔너리 형으로 변환
                }
            }});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}