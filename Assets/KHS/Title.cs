using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
public class User{
    public string userEmail;
    public string userName;

    public User(string email, string name ){
        userEmail = email;
        userName = name;
    }

}

public class TitleManager : MonoBehaviour
{


     DatabaseReference reference;
     Firebase.Auth.FirebaseUser user1;
    // Start is called before the first frame update
    void Start()
    {
            Firebase.Auth.FirebaseAuth auth;
            auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        user1 = auth.CurrentUser;
        // reference = FirebaseDatabase.DefaultInstance.RootReference;
        reference = FirebaseDatabase.DefaultInstance.GetReference("Title");
        User user = new User("hyjkl0124@naver.com","kim");
        string json = JsonUtility.ToJson(user);
        string providerId;
        string uid;
//         if (user1 != null) {
//             foreach (var profile in user1.ProviderData) {
//               // Id of the provider (ex: google.com)
//              providerId = profile.ProviderId;

//     // UID specific to the provider
//              uid = profile.UserId;
//              Debug.Log(uid);
//                  string name = profile.DisplayName;
//     string email = profile.Email;
//          reference.Child("Title").Child(email).SetRawJsonValueAsync(json);
//     // Name, email address, and profile photo Url

//         Debug.Log(providerId);
//             Debug.Log(name);
//                 Debug.Log(email);
//     System.Uri photoUrl = profile.PhotoUrl;
//   }
// }
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