using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoreCollisionScript : MonoBehaviour
{

    public GameObject boneParticleGameObj;
    private ParticleSystem boneParticleSystem;
    private GameHandler gameHandler;

    private void Start()
    {
        gameHandler = FindObjectOfType(typeof(GameHandler)) as GameHandler;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exit" && !DataScript.isExitOccupied)
        {
            Debug.Log("EXIT");
            StartCoroutine(reachedToExit());
            gameHandler.LevelPassed();
        }
        
        else if(collision.gameObject.tag == "Bone")
        {
            Debug.Log("Bone Collected");
            StartCoroutine(boneEated(collision.gameObject));
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

    public IEnumerator boneEated(GameObject bone)
    {
        yield return new WaitForSecondsRealtime(0.7f);
        Vector3 particleSystemPos = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);
        GameObject go = Instantiate(boneParticleGameObj, particleSystemPos, Quaternion.identity) as GameObject;
        boneParticleSystem = go.GetComponent<ParticleSystem>();
        var main = boneParticleSystem.main;
        main.startColor = DataScript.boneColor;
        boneParticleSystem.Play();
        bone.gameObject.SetActive(false);
    }

    public IEnumerator reachedToExit()
    {
        while(transform.localScale.x > 0f)
        {
            transform.localScale -= new Vector3(0.1f,0.1f,0.1f);
            yield return new WaitForSeconds(0.07f);
        }
        
    }

   
}
