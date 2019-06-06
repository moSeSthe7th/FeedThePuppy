using System.Collections;
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
            collision.gameObject.SetActive(false);
            StartCoroutine(boneEated());
            
        }
    }

   
    public IEnumerator boneEated()
    {
        yield return new WaitForSeconds(1.2f);
        GameObject go = Instantiate(boneParticleGameObj, transform.position, Quaternion.identity) as GameObject;
        boneParticleSystem = go.GetComponent<ParticleSystem>();
        boneParticleSystem.Play();
        DataScript.boneCount = DataScript.boneCount + 1;
        boneCounter.SetBoneCounter();
    }
}
