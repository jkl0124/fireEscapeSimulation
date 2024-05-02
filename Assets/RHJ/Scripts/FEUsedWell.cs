using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEUsedWell : MonoBehaviour
{
    [SerializeField] GameObject FeObject;
    [SerializeField] GameObject FeParticle;
    [SerializeField] Quaternion FeRotation_Whenusing;
    void Start()
    {
        FeObject.SetActive(true);
        FeParticle.SetActive(true);
        FeObject.transform.localRotation = FeRotation_Whenusing;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
