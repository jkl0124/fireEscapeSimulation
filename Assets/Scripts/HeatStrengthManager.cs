using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatStrengthManager : MonoBehaviour
{
    public GameObject heatsource;
    [Range(0,10)]
    public int strength = 1;
    public HeatTransferRadial heattransfer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        heattransfer.energy_per_Ray = strength * 0.1f;
    }
}
