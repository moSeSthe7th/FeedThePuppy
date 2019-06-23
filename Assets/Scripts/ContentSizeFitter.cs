using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Classes for arranging Content sizes according to screen
namespace ContentSizeMapping 
{
    public class SizeHandler
    {
        //Arrange platform width convert screen width to world size in x
        public float gameScreenHeight = Camera.main.orthographicSize * 2.0f;
        public float gameScreenWidth = (Camera.main.orthographicSize * 2.0f) * Camera.main.aspect; //gameScreenHeight
    }


    public class ObjectSizeHandler : SizeHandler
    {
        public void ArrangeObjectSize(Transform objectToArrange )
        {
                       
            objectToArrange.transform.localScale = new Vector3(gameScreenWidth / 4f,gameScreenWidth / 4f);
            Vector2 diff = Vector2.one - (Vector2)objectToArrange.transform.localScale;
            objectToArrange.transform.position = diff;//new Vector3(-GetWallPosition() / 4f, -GetGroundPosition() / 4f , 0f);

        }

        public float GetWallPosition()
        {
            return gameScreenWidth / 2f;
        }

        public float GetGroundPosition()
        {
            return gameScreenHeight / 2f;
        }


        public float SetDynamicSize(float defaultScreenSize, float defaultContentSize)
        {
            float maxAllowedScreenDiff = defaultScreenSize / 4f;
            float maxAllowedContentDiff = defaultContentSize / 4f;

            float SizeArranger = (Screen.width - defaultScreenSize) / maxAllowedScreenDiff;

            if (Mathf.Abs(SizeArranger) > 1)
                SizeArranger = (SizeArranger > 1) ? 1 : -1;

            return defaultContentSize + (maxAllowedContentDiff * SizeArranger);

        }
    }
    

}
