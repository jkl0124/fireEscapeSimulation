using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject grabbing_item;
  
    //Singleton
    private static ItemManager _Instance;
    public static ItemManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindAnyObjectByType<ItemManager>();
            }
            return _Instance;
        }
    }

    public GameObject GetGrabbingItem()
    {
        return grabbing_item;
    }
}
