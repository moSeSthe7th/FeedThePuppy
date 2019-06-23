using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//bunlar obstacle ların üstünde de çıkıyor, onların ve dogların üstünde cıkmasın, ground haric herhangi bi yerin üstünde cıkmasınlar,, check fonksiyonu yaz controller managerdan cağır
public class BoneScript : MonoBehaviour
{
    public LayerMask layerMask;
    private SpriteRenderer spriteRenderer;
    


    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = DataScript.boneColor;
    }

    private void OnEnable()
    {
        
        gameObject.GetComponent<BoxCollider2D>().enabled = false;                   //make false here and then create raycasthit because wihjout this line bone sees itself and collides with itself
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.zero, Mathf.Infinity,layerMask);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        //if it collides with nothing, the collider become null,
        //if we put a 2d collider in ground it collides with it or other objects
        if (raycastHit.collider != null)
        {
           
            if (raycastHit.collider.gameObject.tag != "Ground")
            {
                DataScript.boneCount--;
                gameObject.SetActive(false);
                Debug.Log(raycastHit.collider.gameObject.tag);      // burada oyun içi bi uyarı verilebilir belki
            }
            else
            {
                StartCoroutine(BoneThrowAnimation());
            }

            
            Debug.Log(raycastHit.collider.gameObject.tag);
           
        }

        if (gameObject.activeSelf)
        {
            StartCoroutine(BoneThrowAnimation());
        }
        
        
    }
    
    IEnumerator BoneThrowAnimation()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Quaternion initialRotation = transform.rotation;
        Vector3 initialScale = transform.localScale;

        transform.localScale = new Vector3(3f, 3f, 3f);

        for(float i = transform.localScale.x; i > initialScale.x; i-= 0.1f)
        {
            float randomFloatx = Random.Range(4f, 8f);
            float randomFloaty = Random.Range(4f, 8f);
            float randomFloatz = Random.Range(4f, 8f);
            transform.localScale = new Vector3(i, i, 0f);
            transform.Rotate(new Vector3(randomFloatx, randomFloaty, randomFloatz));
            yield return new WaitForSecondsRealtime(0.013f);
        }

        transform.rotation = initialRotation;
        transform.localScale = initialScale;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
