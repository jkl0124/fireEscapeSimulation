using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeChildObjectActive : MonoBehaviour
{
    [SerializeField] List<GameObject> childs;
      private void OnEnable()
    {
        foreach (GameObject child in childs)
        {
            child.SetActive(true);
        }
    }
}
