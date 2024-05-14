using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEMinigameButton : MonoBehaviour
{
    [SerializeField] GameObject nowUI;
    [SerializeField] GameObject nextUI;
    [SerializeField] GameObject nowButton;
    [SerializeField] GameObject nextButton;


    public void Correct()
    {
        nowUI.SetActive(false);
        nowButton.SetActive(false);
        nextUI.SetActive(true);
        if (nextButton != null)
        {
            nextButton.SetActive(true);
        }
        else if (nextButton == null)
        {
            transform.parent.parent.gameObject.SetActive(false);
        }
    }

    public void MouseLockdisable()
    {
        SojaExiles.MouseLook.Instance.mouseLock = false;
    }

    public void MakeItemUsingState()
    {
        GameObject FE = ItemManager.Instance.grabbing_item;
        ItemUse itemUse = FE.GetComponent<ItemUse>();
        itemUse.item_used = true;
    }

}
