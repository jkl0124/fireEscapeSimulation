using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firecontroller : MonoBehaviour
{
    public bool playAura = true;
    public List<ParticleSystem> particle;
    public List<ParticleSystem> smogandsmallfire;
    [Range(0.0f, 10.0f)]
    public float firestrength;

    [Range(0.2f, 6.0f)]
    public float lifetime;
    [Range(0.2f, 0.8f)]
    public float speed;

    public HeatStrengthManager heatStrengthManager;


    void Update()
    {
        heatStrengthManager.strength = (int)firestrength;
        for (int i = 0; i < particle.Count; i++)
        {
            var main = particle[i].main;
            main.startLifetime = remap(firestrength, 0.0f, 10.0f, 2.0f, 6.0f);
            main.startSpeed = remap(firestrength, 0.0f, 10.0f, 0.2f, 0.8f);
            if (!particle[i].isPlaying)
            {
                if (playAura && firestrength != 0)
                    particle[i].Play();
            }
            if (particle[i].isPlaying)
            {
                if (!playAura || firestrength == 0)
                    particle[i].Stop();
            }
        }

        for (int i = 0; i < smogandsmallfire.Count; i++)
        {
            var col = smogandsmallfire[i].colorOverLifetime;
            col.enabled = true;

            Gradient grad = new Gradient();

            float alphaMin = Mathf.Clamp(firestrength * 0.1f,0,0.9f);
            float alphaMax = Mathf.Clamp(firestrength * 0.1f,0,0.9f); // ���İ��� �ִ� ���氪�� firestrength�� ����ϵ��� ����

            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
            alphaKeys[0] = new GradientAlphaKey(alphaMin, 1.0f);
            alphaKeys[1] = new GradientAlphaKey(alphaMax, 1.0f);

            grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f) }, alphaKeys);

            col.color = grad;

            /*
            if (!smogandsmallfire[i].isPlaying)
            {
                if (firestrength >= 4.0f)
                    smogandsmallfire[i].Play();
            }
            if (smogandsmallfire[i].isPlaying)
            {
                if (firestrength <= 4.0f)
                    smogandsmallfire[i].Stop();
            }
            */
        }
        

    }


    public static float remap(float val, float in1, float in2, float out1, float out2)  
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }
}
