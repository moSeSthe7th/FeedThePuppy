using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoreCollisionScript : MonoBehaviour
{

    public GameObject boneParticleGameObj;
    private ParticleSystem boneParticleSystem;
    private BoneCounter boneCounter;
    private GameHandler gameHandler;

    private void Start()
    {
        boneCounter = FindObjectOfType(typeof(BoneCounter)) as BoneCounter;
        gameHandler = FindObjectOfType(typeof(GameHandler)) as GameHandler;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exit")
        {
            Debug.Log("EXIT");
            gameHandler.LevelPassed();
        }
        
        else if(collision.gameObject.tag == "Bone")
        {
            Debug.Log("Bone Collected");
            StartCoroutine(boneEated());
            collision.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bad Dogs")
        {
            gameHandler.GameOver();
            Debug.Log("GAME OVER");
        }
    }

    public IEnumerator boneEated()
    {
        yield return new WaitForSeconds(0.7f);
        GameObject go = Instantiate(boneParticleGameObj, transform.position, Quaternion.identity) as GameObject;
        boneParticleSystem = go.GetComponent<ParticleSystem>();
        boneParticleSystem.Play();
        DataScript.boneCount = DataScript.boneCount + 1;
        boneCounter.SetBoneCounter();
    }

   
}
