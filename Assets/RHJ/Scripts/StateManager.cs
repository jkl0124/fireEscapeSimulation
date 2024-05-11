using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private float hp;
    private float oxygen;
    private float gas;

    [SerializeField, Range(0, 100)]
    private float maxHp = 100f;
    [SerializeField, Range(0, 100)]
    private float maxOxygen = 100f;
    [SerializeField, Range(0, 100)]
    private float maxGas = 100f;

    //Singleton
    private static StateManager _Instance;
    public static StateManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindAnyObjectByType<StateManager>();
            }
            return _Instance;
        }
    }

    private void Start()
    {
        InitializeStates();
    }

    private void InitializeStates()
    {
        hp = maxHp;
        oxygen = maxOxygen;
        gas = 0;
    }

    public void UpdateHp(float value)
    {
        hp += value;
        hp = Mathf.Clamp(hp, 0, maxHp);
    }

    public void UpdateOxygen(float value)
    {
        oxygen += value;
        oxygen = Mathf.Clamp(oxygen, 0, maxOxygen);
    }

    public void UpdateGas(float value)
    {
        gas += value;
        gas = Mathf.Clamp(gas, 0, maxGas);
    }

    public int ReturnHP()
    {
        return (int)hp;
    }
    public int ReturnOxygen()
    {
        return (int)oxygen;
    }
    public int ReturnGas()
    {
        return (int)gas;
    }
}
