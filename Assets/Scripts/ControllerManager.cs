using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    private BoardManager boardManager;

    public GameObject bone;

    public Vector2 mousePos;
    private Vector2 roundedMousePos;
   // private Vector2 touchPos;
    private Vector2 roundedTouchPos;
    
    void Start()
    {
        boardManager = GetComponent<BoardManager>();
    }

    
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Ended && !DataScript.isGamePaused)
            {
                roundedTouchPos = new Vector2(Mathf.Round(touch.position.x), Mathf.Round(touch.position.y));
                bone = ObjectPooler.instance.GetPooledObject(boardManager.pooledBoneList);
                if (bone != null)
                {
                    putBone(bone, roundedTouchPos);
                }
                else
                {
                    Debug.Log("Bone List is null");
                }
            }
           

        }

        #region mouseControls
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        roundedMousePos = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
        if (Input.GetMouseButtonUp(0) && !DataScript.isGamePaused)
        {
            bone = ObjectPooler.instance.GetPooledObject(boardManager.pooledBoneList);
            if (bone != null)
            {
                putBone(bone, roundedMousePos);
            }
            else
            {
                Debug.Log("Bone List is null");
            }
        }
        #endregion
    }

    public void putBone(GameObject bone ,Vector2 bonePos)
    {
        bone.transform.position = bonePos;
        bone.gameObject.SetActive(true);
    }
}
