﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadDogsCollisionScript : MonoBehaviour
{
    public GameObject boneParticleGameObj;
    private ParticleSystem boneParticleSystem;

    private BoneCounter boneCounter;

    private void Start()
    {
        boneCounter = FindObjectOfType(typeof(BoneCounter)) as BoneCounter;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bone")
        {
            
            StartCoroutine(boneEated(collision.gameObject));
            
        }
    }

   
    public IEnumerator boneEated(GameObject bone)
    {
        yield return new WaitForSecondsRealtime(1.2f);
        GameObject go = Instantiate(boneParticleGameObj, transform.position, Quaternion.identity) as GameObject;
        boneParticleSystem = go.GetComponent<ParticleSystem>();
        var main = boneParticleSystem.main;
        main.startColor = DataScript.boneColor;
        boneParticleSystem.Play();
        DataScript.boneCount = DataScript.boneCount + 1;
        boneCounter.SetBoneCounter();
        bone.gameObject.SetActive(false);
    }
}
