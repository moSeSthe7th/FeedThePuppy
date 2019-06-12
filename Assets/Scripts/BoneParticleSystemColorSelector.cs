using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneParticleSystemColorSelector : MonoBehaviour
{
    private ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        var main = particleSystem.main;
        main.startColor = new Color(0,0,0);
    }

   
}
