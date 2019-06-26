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
        public float defatultGameWidth = 3.5f; //iphone x game width

        protected Vector2 defaultScreenSize = new Vector2(1125f,2436f); //iphone x screen width and screen height
        protected Vector2 ScreenSize = new Vector2(Screen.width, Screen.height);
    }

    enum ObjectPlace
    {
        pMiddle,

    }

   public enum Object
    {
        Board,
        Default
    }

    public class ObjectSizeHandler : SizeHandler
    {
        public void ArrangeObjectSize(Transform objectToArrange,Object size = Object.Default, float cSize = 1f) 
        {
            Vector2 oldSize = (Vector2)objectToArrange.transform.localScale;
            Vector2 newSize = Vector2.one;

            Debug.Log("GameScreenWidth is : " + gameScreenWidth + ". Game screen heigth is  : " + gameScreenHeight);
            Debug.Log("Size before changing : " + oldSize);
            Debug.Log(defaultScreenSize + " and current  " + ScreenSize);         

            switch(size)
            {

                case Object.Board:

                    float defaultColumnSize = 3f;

                    float columnDiff = defaultColumnSize / cSize;
                    float boardSize = oldSize.x * columnDiff;

                    boardSize = ChangeSizeLinearly(boardSize);

                    newSize = new Vector2(boardSize, boardSize);

                    objectToArrange.transform.localScale = newSize;

                    float posColumnDiff = 1f;
                    if(!Mathf.Approximately(defaultColumnSize,cSize))
                    {
                        posColumnDiff =  (cSize / defaultColumnSize) - (oldSize.x - newSize.x);
                    }
                    Vector3 middlePos = Camera.main.ScreenToWorldPoint((Vector3)(ScreenSize) / 2f);
                    objectToArrange.transform.position = new Vector3( middlePos.x - posColumnDiff ,middlePos.y - posColumnDiff, 0f);
                    break;
                case Object.Default:
                default:

                    float tmpSize = ChangeSizeLinearly(oldSize.x);

                    newSize = new Vector2(tmpSize, tmpSize);
                    objectToArrange.transform.position += (Vector3)PosDiffAccordingToChangedSize(oldSize, newSize); 
                    objectToArrange.transform.localScale = newSize;

                    break;
                

            }

           
           // Vector2 diff = Vector2.one - (Vector2)objectToArrange.transform.localScale;
           // objectToArrange.transform.position = diff;//new Vector3(-GetWallPosition() / 4f, -GetGroundPosition() / 4f , 0f);

        }

        float ChangeSizeLinearly(float oldSize)
        {
            float size = (gameScreenWidth * oldSize) / defatultGameWidth; //doğrusal orantıyla artıyor size
            return size;
        }

        Vector2 PosDiffAccordingToChangedSize(Vector2 oldSize, Vector2 newSize)
        {
            Vector2 diff = new Vector2((oldSize.x - newSize.x), (oldSize.y - newSize.y));
            return diff;
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
