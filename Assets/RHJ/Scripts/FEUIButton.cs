using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEUIButton : MonoBehaviour
{
    [SerializeField] GameObject parentUI;
    [SerializeField] GameObject Minigame;
    private GameObject FE;
    public void NotUseButton()
    {
        parentUI.SetActive(false);
        SojaExiles.MouseLook.Instance.mouseLock = false;
    }

    public void UseButton()
    {
        FE = ItemManager.Instance.grabbing_item;
        ItemUse itemUse = FE.GetComponent<ItemUse>();
        itemUse.item_used = true;
        parentUI.SetActive(false);
        FE.SetActive(false);
        Minigame.SetActive(true);
    }
}
