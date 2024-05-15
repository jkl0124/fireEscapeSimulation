using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSingleManager : MonoBehaviour
{
    // public static TitleSingleManager Instance = null;
    private static TitleSingleManager _instance;
    public static TitleSingleManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TitleSingleManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("TitleSingleManager");
                    _instance = go.AddComponent<TitleSingleManager>();
                }
            }
            return _instance;
        }
    }

    void Awake()
    {
        // if (Instance == null)
        // {
        //     Instance = new TitleSingleManager();
        // }
        // else if (Instance != this)
        // {
        //     Destory(gameObject);
        // }
        // Instance = this;
        // DontDestoryOnLoad(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public long FE_first_use;
    public long T_Fire_fighter;
    public long FE_use;
    public long FE_all_use;
    public long first_bucket;
    public long bucket_success;
    public long handkerchief_use;
    public long swift_evacuation;
    public long safe_evacuation;
    public long FITMOS;

    public void setTitle(long FE_first_use, long T_Fire_fighter, long FE_use, long FE_all_use, long first_bucket, long bucket_success, long handkerchief_use, long swift_evacuation, long safe_evacuation, long FITMOS)
    {
        this.FE_first_use = FE_first_use;
        this.T_Fire_fighter = T_Fire_fighter;
        this.FE_use = FE_use;
        this.FE_all_use = FE_all_use;
        this.first_bucket = first_bucket;
        this.bucket_success = bucket_success;
        this.handkerchief_use = handkerchief_use;
        this.swift_evacuation = swift_evacuation;
        this.safe_evacuation = safe_evacuation;
        this.FITMOS = FITMOS;

    }


    public void setFE_first_use()
    {
        this.FE_first_use++;
    }
    public void setT_Fire_fighter()
    {
        this.T_Fire_fighter++;
    }

    public void setFE_use()
    {
        this.FE_use++;
    }
    public void setFE_all_use()
    {
        this.FE_all_use++;
    }

    public void setfirst_bucket()
    {
        this.first_bucket++;
    }

    public void setbucket_success()
    {
        this.bucket_success++;
    }

    public void sethandkerchief_use()
    {
        this.handkerchief_use++;
    }

    public void setswift_evacuation()
    {
        this.swift_evacuation++;
    }

    public void setsafe_evacuation()
    {
        this.safe_evacuation++;
    }
    public void setFITMOS()
    {
        this.FITMOS++;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
