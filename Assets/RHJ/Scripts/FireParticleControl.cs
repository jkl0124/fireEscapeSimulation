using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticleControl : MonoBehaviour
{
    public ParticleSystem particles;
    public float shrinkRate = 0.1f;
    public float minLifetime = 0.05f; // 최소 수명

    private void OnMouseDown()
    {
        if (ItemManager.Instance.grabbing_item.GetComponentInChildren<FEClickParticleSystem>() != null && !ItemManager.Instance.grabbing_item.GetComponentInChildren<FEClickParticleSystem>().cannotuse)
        {
            ShrinkParticles();
        }
    }

    void ShrinkParticles()
    {
        ParticleSystem.MainModule mainModule = particles.main;
        float currentLifetime = mainModule.startLifetime.constant;
        float currentSimulationSpeed = particles.main.simulationSpeed;

        // 파티클의 수명과 시뮬레이션 스피드를 점진적으로 줄여가며 파티클을 사라지게 함
        float newLifetime = Mathf.Lerp(currentLifetime, 0, shrinkRate * Time.deltaTime);
        float newSimulationSpeed = Mathf.Lerp(currentSimulationSpeed, 0, shrinkRate * Time.deltaTime);

        // 파티클의 수명이 최소 수명보다 작거나 같으면 파티클을 비활성화함
        if (newLifetime <= minLifetime)
        {
            particles.gameObject.SetActive(false);
        }
        else
        {
            mainModule.startLifetime = newLifetime;
            mainModule.simulationSpeed = newSimulationSpeed;
        }
    }
}
