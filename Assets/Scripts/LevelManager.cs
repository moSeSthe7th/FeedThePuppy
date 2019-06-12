using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private BoardManager boardManager;

    public int columns;
    public int rows;
    public int boneCount;

    public List<Vector3> dogPos = new List<Vector3>();
    public List<Vector3> playerPos = new List<Vector3>();
    public List<Vector3> obstaclepos = new List<Vector3>();

    public Vector3 exitPos = new Vector3();

    public string levelColorCode;

    void Start()
    {
        boardManager = GetComponent<BoardManager>();
    }

    public void LevelData(int level)            // çıkış gameobjelerini ekle
    {
        switch (level)              
        {
            case 1:
                columns = 3;
                rows = 1;
                boneCount = 2;

                playerPos.Add(new Vector3(0f, 0f, 0f));
                exitPos = new Vector3(2f, 0f, 0f);

                levelColorCode = "Red";

                break;
            case 2:
                columns = 3;
                rows = 3;
                boneCount = 5;

                playerPos.Add(new Vector3(0f, 2f, 0f));
                obstaclepos.Add(new Vector3(2f, 2f, 0f));
                obstaclepos.Add(new Vector3(1f, 1f, 0f));
                exitPos = new Vector3(2f, 0f, 0f);

                levelColorCode = "Red";

                break;
            case 3:
                columns = 3;
                rows = 3;
                boneCount = 3;
                
                playerPos.Add(new Vector3(0f, 0f, 0f));
                dogPos.Add(new Vector3(1f, 1f, 0f));
                obstaclepos.Add(new Vector3(2f, 2f, 0f));
                obstaclepos.Add(new Vector3(0f, 2f, 0f));
                exitPos = new Vector3(2f, 0f, 0f);

                levelColorCode = "Red";

                break;
            case 4:
                columns = 3;
                rows = 3;
                boneCount = 3;

                playerPos.Add(new Vector3(1f, 1f, 0f));
                dogPos.Add(new Vector3(1f, 0f, 0f));
                exitPos = new Vector3(2f, 0f, 0f);

                levelColorCode = "Red";
                break;
            case 5:
                columns = 3;
                rows = 3;
                boneCount = 6;      //7 de olabilir

                playerPos.Add(new Vector3(0f, 2f, 0f));
                dogPos.Add(new Vector3(0f, 1f, 0f));
                exitPos = new Vector3(2f, 0f, 0f);

                levelColorCode = "Red";

                break;
            case 6:
                columns = 3;
                rows = 3;
                boneCount = 6;

                playerPos.Add(new Vector3(2f, 2f, 0f));
                dogPos.Add(new Vector3(1f, 1f, 0f));
                exitPos = new Vector3(2f, 0f, 0f);

                levelColorCode = "Red";

                break;
        }
        

    }
}


//to add a new object you need to add its position list to top of level manager and board manager. populate the list from the leveldata in levelmanager and use it in the board manager.
//to add a new level only enter leveldata in levelmanager the positions of gameobjects
