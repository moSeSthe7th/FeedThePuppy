using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadDogsCollisionScript : MonoBehaviour
{
    public GameObject boneParticleGameObj;
    private ParticleSystem boneParticleSystem;

    private MergerScript mergerScript;

    private void Start()
    {
        mergerScript = FindObjectOfType(typeof(MergerScript)) as MergerScript;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exit")
        {
            DataScript.isExitOccupied = true;
        }
        if(collision.gameObject.tag == "Bone")
        {
            StartCoroutine(boneEated(collision.gameObject));
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            Vector3 middleOfCollisionPos = new Vector3((gameObject.transform.position.x + collision.gameObject.transform.position.x) / 2,
                (gameObject.transform.position.y + collision.gameObject.transform.position.y) / 2,
                (gameObject.transform.position.z + collision.gameObject.transform.position.z) / 2);
            Vector3 roundedCollisionPos = new Vector3(Mathf.Round(middleOfCollisionPos.x), Mathf.Round(middleOfCollisionPos.y), Mathf.Round(middleOfCollisionPos.z));

            StartCoroutine(mergerScript.MergeObjects(gameObject, roundedCollisionPos));
            mergerScript.isMergeAvailable = false;

           
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
