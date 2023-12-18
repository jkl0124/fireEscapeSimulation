using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowVR : MonoBehaviour
{
    Transform CameraTransform;
    public Vector3 Offset;
    public float smoothSpeed = 2.0f; // 부드러운 이동을 위한 속도 변수

    void Awake()
    {
        CameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = CameraTransform.position + Offset;
        // Lerp 함수를 사용하여 현재 위치에서 목표 위치로 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        transform.eulerAngles = new Vector3(CameraTransform.rotation.x, 0, CameraTransform.rotation.z);
    }
}
