using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoreCollisionScript : MonoBehaviour
{

    public GameObject boneParticleGameObj;
    private ParticleSystem boneParticleSystem;
    private GameHandler gameHandler;

    private Animator animator;

    private MergerScript mergerScript;

    private void Start()
    {
        gameHandler = FindObjectOfType(typeof(GameHandler)) as GameHandler;
        mergerScript = FindObjectOfType(typeof(MergerScript)) as MergerScript;

        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("isBoreFeared", false);
        StartCoroutine(StartAnimationOfBore());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exit" && !DataScript.isExitOccupied)
        {
            StartCoroutine(ReachedToExit());
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
            StartCoroutine(gameOverAnim());
        }
        if(collision.gameObject.tag == this.gameObject.tag)
        {
            Vector3 middleOfCollisionPos = new Vector3((gameObject.transform.position.x + collision.gameObject.transform.position.x) / 2,
              (gameObject.transform.position.y + collision.gameObject.transform.position.y) / 2,
              (gameObject.transform.position.z + collision.gameObject.transform.position.z) / 2);
            Vector3 roundedCollisionPos = new Vector3(Mathf.Round(middleOfCollisionPos.x), Mathf.Round(middleOfCollisionPos.y), Mathf.Round(middleOfCollisionPos.z));

            StartCoroutine(mergerScript.MergeObjects("Bore", roundedCollisionPos));
            DataScript.isMergeAvailable = false;
            Destroy(this.gameObject);
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

    public IEnumerator ReachedToExit()
    {
        while(transform.localScale.x > 0f)
        {
            transform.localScale -= new Vector3(0.1f,0.1f,0.1f);
            yield return new WaitForSeconds(0.07f);
        }
        
    }

    public IEnumerator gameOverAnim()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        animator.SetBool("isBoreFeared", true);
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        while (transform.position.x < 50f)
        {
            Vector3 vector3 = transform.position;
            vector3.x += 0.2f;
            transform.position = vector3;
            yield return new WaitForSeconds(0.01f);
        }

        /*transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        while (transform.localScale.x > 0f)
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            transform.RotateAroundLocal(new Vector3(0f, 0f, 1f), 1f);
            yield return new WaitForSeconds(0.07f);
        }*/
    }

    public IEnumerator StartAnimationOfBore()
    {
        float waitTime = Random.Range(0f, 3f);
        yield return new WaitForSecondsRealtime(waitTime);

        animator.SetBool("isBoreStarted", true);
    }
}
