using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticleControl : MonoBehaviour
{
    public ParticleSystem particles;
    public float shrinkRate = 0.1f;
    public float minLifetime = 0.05f; // �ּ� ����

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

        // ��ƼŬ�� ����� �ùķ��̼� ���ǵ带 ���������� �ٿ����� ��ƼŬ�� ������� ��
        float newLifetime = Mathf.Lerp(currentLifetime, 0, shrinkRate * Time.deltaTime);
        float newSimulationSpeed = Mathf.Lerp(currentSimulationSpeed, 0, shrinkRate * Time.deltaTime);

        // ��ƼŬ�� ������ �ּ� ������ �۰ų� ������ ��ƼŬ�� ��Ȱ��ȭ��
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
