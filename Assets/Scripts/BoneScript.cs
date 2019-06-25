using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BoneScript : MonoBehaviour
{
    public LayerMask layerMask;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer boneShadow;
    private SpriteRenderer[] spriteRenderers;

    private void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        spriteRenderer = spriteRenderers[0];
        if (spriteRenderers[1] != null)
        {
            boneShadow = spriteRenderers[1];
        }

        spriteRenderer.color = DataScript.boneColor;
    }


    private void OnEnable()
    {
        
        
        boneShadow.gameObject.SetActive(false);
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

        for(float i = transform.localScale.x; i > initialScale.x; i-= 0.2f)
        {
            
            transform.localScale = new Vector3(i, i, 0f);
            transform.Rotate(new Vector3(1.5f, 1.5f, 1.5f));
            yield return new WaitForSecondsRealtime(0.005f);
        }

        boneShadow.gameObject.SetActive(true);
        transform.rotation = initialRotation;
        transform.localScale = initialScale;
        
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
