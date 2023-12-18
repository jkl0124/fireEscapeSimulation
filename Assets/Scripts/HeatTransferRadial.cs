using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class HeatTransferRadial: MonoBehaviour
{
    private NativeArray<RaycastCommand> _raycastCommands;
    private NativeArray<RaycastHit> _raycastHits;
    private JobHandle _jobHandle;

    private NativeArray<RaycastCommand> _raycastCommands2;
    private NativeArray<RaycastHit> _raycastHits2;
    private JobHandle _jobHandle2;

    public bool visible;
    public int count = 0;
    public int count2 = 0;

    public int objectnum = 0;

    [Header("방사형")]

    [SerializeField]
    bool send;

    [SerializeField]
    public int NumberOfRay;
    [SerializeField]
    public float EnergyFromRay;
    [SerializeField]
    float maxDistance = 50f;
    public Dictionary<HeatTransferRadial, float> neighbor = new Dictionary<HeatTransferRadial, float>();
    public float energy_per_Ray = .01f;
    Vector3[] points;
    HeatTransferRadial[] prePlayers;

    private void Awake()
    {
        _raycastCommands = new NativeArray<RaycastCommand>(100000, Allocator.Persistent);
        _raycastCommands2 = new NativeArray<RaycastCommand>(50000, Allocator.Persistent);
        _raycastHits = new NativeArray<RaycastHit>(100000, Allocator.Persistent);
        _raycastHits2 = new NativeArray<RaycastHit>(50000, Allocator.Persistent);
    }

    void Start()
    {
        prePlayers = GameObject.FindObjectsOfType<HeatTransferRadial>();
    }


    void Update()
    {
        points = GenerateVectorArray(NumberOfRay);
        count = 0;
        count2 = 0;
        _jobHandle.Complete();
        _jobHandle2.Complete();

        //Debug.Log($"갱신,{count}");
        float f = 0;
        foreach (KeyValuePair<HeatTransferRadial, float> item in neighbor)
        {
            if (item.Key.gameObject.activeInHierarchy == true)
            {
                f += item.Value;
            }
        }
        EnergyFromRay = f;

        GetNearPlayers(maxDistance, neighbor);
        _jobHandle = RaycastCommand.ScheduleBatch(_raycastCommands, _raycastHits, 1);
        _jobHandle2 = RaycastCommand.ScheduleBatch(_raycastCommands2, _raycastHits2, 1);
    }

    void FixedUpdate()
    {
    }

    // 지정한 Number of Ray 에 따라 레이 방향 벡터 생성 
    Vector3[] GenerateVectorArray(int density)
    {
        Vector3[] points = new Vector3[density];
        float phi = Mathf.PI * (3 - Mathf.Sqrt(5));

        for (int i = 0; i < density; i++)
        {
            float y = 1 - (i / (float)(density - 1)) * 2;
            float radius = Mathf.Sqrt(1 - y * y);

            double theta = phi * i;

            float x = Mathf.Cos(((float)theta)) * radius;
            float z = Mathf.Sin(((float)theta)) * radius;

            points[i] = new Vector3(x, y, z);
        }
        return points;
    }

 

    float calculatewithRay_step1(GameObject player)
    {

        float sum = 0;

        for (int i = 0; i < points.Length; i++)
        {
            _raycastCommands[count] = new RaycastCommand(transform.position, points[i]);
            RaycastHit hit = _raycastHits[count];
            count += 1;
                if (hit.collider != null)
                {
                    if (hit.transform.gameObject == player)
                    {
                        sum += energy_per_Ray;
                        Debug.DrawLine(transform.position, hit.point, Color.red);
                        //if (hit.transform.gameObject.layer == 2)

                    }
                    
                    
                    else if (hit.transform.gameObject.layer == 3)
                    {
                        _raycastCommands2[count2] = new RaycastCommand(hit.point, points[i]);
                        RaycastHit hit2 = _raycastHits2[count2];
                        count2 += 1;
                        
                        if(hit2.collider != null)
                        { 
                            if (hit2.transform.gameObject == player)
                            {
                                if(hit.transform.GetComponent<transparent>() != null)
                                { 
                                    sum += energy_per_Ray * hit.transform.GetComponent<transparent>().transparancy;
                                    Debug.DrawLine(hit.point, hit2.point, Color.green);
                                }
                            }
                        }  
                    }
                   
                    else
                    {
                        Debug.DrawRay(hit.point, points[i] * maxDistance, Color.blue);
                    }
                }

                else
                {
                    Debug.DrawRay(transform.position, points[i] * maxDistance, Color.blue);
                }
        }
        return sum;
     }



    //distance 내에 들어와있는 경우 열전달 진행, calculatewithRay_step1 함수를 이용해 열전달값 계산 후 HeatTransfalRadial 컴포넌트에 열전달 값 업데이트

    void GetNearPlayers(float distance, Dictionary<HeatTransferRadial, float> diction)
    {
        for (int i = 0; i < prePlayers.Length; i++)
        {
            if (Vector3.Distance(prePlayers[i].transform.position, transform.position) < distance)
            {
                if (prePlayers[i].neighbor.ContainsKey(GetComponent<HeatTransferRadial>()))
                    prePlayers[i].neighbor[GetComponent<HeatTransferRadial>()] = calculatewithRay_step1(prePlayers[i].gameObject);
                else
                {
                    prePlayers[i].neighbor.Add(GetComponent<HeatTransferRadial>(), calculatewithRay_step1(prePlayers[i].gameObject));
                }
            }
        }
    }

    private void OnDestroy()
    {
        _jobHandle.Complete();
        _raycastCommands.Dispose();
        _raycastHits.Dispose();
        _jobHandle2.Complete();
        _raycastCommands2.Dispose();
        _raycastHits2.Dispose();
    }
}