using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEUsedWell : MonoBehaviour
{
    private GameObject FeObject;
    [SerializeField] Quaternion FeRotation_Whenusing;

    private void OnEnable()
    {
        FeObject = ItemManager.Instance.grabbing_item;
        FeObject.SetActive(true);
        ItemUse itemUse = FeObject.GetComponent<ItemUse>();
        itemUse.FE_opened = true;
        FeObject.transform.localRotation = FeRotation_Whenusing;
    }

}
