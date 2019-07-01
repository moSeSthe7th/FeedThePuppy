using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadDogsMovement : MonoBehaviour
{
    public LayerMask layerMask;
    
    private Animator animator;

    void Start()
    {
        
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("isBadDogEating", false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D raycastDown = Physics2D.Raycast(transform.position, Vector2.down, 1f, layerMask);
        RaycastHit2D raycastUp = Physics2D.Raycast(transform.position, Vector2.up, 1f, layerMask);
        RaycastHit2D raycastRight = Physics2D.Raycast(transform.position, Vector2.right, 1f, layerMask);
        RaycastHit2D raycastLeft = Physics2D.Raycast(transform.position, Vector2.left, 1f, layerMask);

        //if it collides with nothing, the collider become null,
        //if we put a 2d collider in ground it collides with it or other objects
        if (raycastDown.collider != null && raycastDown.collider.gameObject.tag == "Bone" && DataScript.canMove)
        {
            StartCoroutine(moveToPositionSmoothly(gameObject, raycastDown.collider.gameObject.transform.position));
            animator.SetBool("isBadDogEating", true);
        }
        else if (raycastUp.collider != null && raycastUp.collider.gameObject.tag == "Bone" && DataScript.canMove)
        {
            StartCoroutine(moveToPositionSmoothly(gameObject, raycastUp.collider.gameObject.transform.position));
            animator.SetBool("isBadDogEating", true);
        }
        else if (raycastRight.collider != null && raycastRight.collider.gameObject.tag == "Bone" && DataScript.canMove)
        {
            StartCoroutine(moveToPositionSmoothly(gameObject, raycastRight.collider.gameObject.transform.position));
            animator.SetBool("isBadDogEating", true);
        }
        else if (raycastLeft.collider != null && raycastLeft.collider.gameObject.tag == "Bone" && DataScript.canMove)
        {
            StartCoroutine(moveToPositionSmoothly(gameObject, raycastLeft.collider.gameObject.transform.position));
            animator.SetBool("isBadDogEating", true);
        }
        
    }

    //second part was another gameobject called "to" but it changes the direction of the puppy
    // while walking so i decided to change it with a vector3 pos which is taken at the start of the function
    public IEnumerator moveToPositionSmoothly(GameObject from, Vector3 toGameobjectsPos)
    {
        Debug.Log("Entered move to position smoothly");
        Debug.Log("From: " + from.transform.position);
        Debug.Log("To: " + toGameobjectsPos);
        DataScript.canMove = false;
        

        while (from.transform.position != toGameobjectsPos)
        {
            from.transform.position = Vector3.MoveTowards(from.transform.position, toGameobjectsPos, 10f * Time.deltaTime);
            yield return new WaitForSecondsRealtime(0.04f);
        }

        DataScript.canMove = true;

        yield return new WaitForSecondsRealtime(0.3f);
        animator.SetBool("isBadDogEating", false);
    }
}
