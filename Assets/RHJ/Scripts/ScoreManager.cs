using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int time_point = 0;
    public int oxygen_point = 0;
    public int fire_point = 0;
    public int bonus_point = 0;
    public int minus_point = 0;

    public int ending_index = 0;


    // Singleton
    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("ScoreManager");
                    _instance = go.AddComponent<ScoreManager>();
                }
            }
            return _instance;
        }


    }

    void Awake()
    {
        // Non-Lazy DDOL Singleton
        DontDestroyOnLoad(gameObject);
    }


    // Call when player do ending behavior 
    public void PlayerViewedEnding(int endingIndex)
    {
        ending_index = endingIndex;

        SceneManager.LoadScene(endingIndex);
    }

}
