using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class testDB : MonoBehaviour
{
    public GameObject Button;
    // Start is called before the first frame update
    public void getTitle()
    {
        DBRepository.Instance.checkTitle();
    }

    public void getTestFireExtinguisher()
    {
        // DBRepository.Instance.useFireExtinguisher();
        // TitleSingleManager.Instance.FISM++;
        TitleSingleManager.Instance.FITMOS++;
    }

    public void checkLoginTitle()
    {
        // Debug.Log(TitleSingleManager.Instance.FISM);
        DBRepository.Instance.saveDB();
    }
}
