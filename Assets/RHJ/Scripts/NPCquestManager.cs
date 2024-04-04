using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCquestManager : MonoBehaviour
{
    public enum process
    {
        None,
        BeforeMeet,
        firsttalk,
        needhelp,
        end
    }

    public process nowProcess = process.None;
    public process nextProcess = process.None;

    void Update()
    {
        if (nowProcess != nextProcess)
        {
            nowProcess = nextProcess;
            switch (nowProcess)
            {
                case process.BeforeMeet:
                    
                    break;
            }
        }
    }


    private static NPCquestManager _instance;
    public static NPCquestManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<NPCquestManager>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("NPCquestManager");
                    _instance = singletonObject.AddComponent<NPCquestManager>();
                }
            }
            return _instance;
        }
    }


}
