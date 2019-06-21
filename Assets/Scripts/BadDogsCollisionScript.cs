using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadDogsCollisionScript : MonoBehaviour
{
    public GameObject boneParticleGameObj;
    private ParticleSystem boneParticleSystem;
    

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
        Vector3 particleSystemPos = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);
        GameObject go = Instantiate(boneParticleGameObj, particleSystemPos, Quaternion.identity) as GameObject;
        boneParticleSystem = go.GetComponent<ParticleSystem>();
        var main = boneParticleSystem.main;
        main.startColor = DataScript.boneColor;
        boneParticleSystem.Play();
        bone.gameObject.SetActive(false);
    }
}
