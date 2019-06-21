using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private LevelManager levelManager;
    private CameraScript cameraScript;

    public int columns;
    public int rows;
    public int totalCol;
    public int totalRow;

    public GameObject ground;
    public GameObject dog;
    public GameObject bore;
    public GameObject obstacle;
    public GameObject bone;
    public GameObject exit;
    

    public List<Vector3> dogPos = new List<Vector3>();
    public List<Vector3> playerPos = new List<Vector3>();
    public List<Vector3> obstaclepos = new List<Vector3>();
    public List<GameObject> pooledBoneList = new List<GameObject>();
    public Vector3 exitPos = new Vector3();

    public List<Vector3> gridPositions = new List<Vector3>();

    public string levelColorCode;

    public int currentLevel;
    
    void Start()
    {
        cameraScript = FindObjectOfType(typeof(CameraScript)) as CameraScript;
        levelManager = GetComponent<LevelManager>();

        totalCol = 10;
        totalRow = 10;

        LevelCreator(currentLevel);
    }

   

    void InitializeList()
    {
        gridPositions.Clear();


       

         for (int x = columns-1; x > -1; x--)                         
         {
             for (int y = rows-1; y > -1; y--)
             {
                 gridPositions.Add(new Vector3(x, y, 0f));
                 Instantiate(ground, new Vector3(x, y, 0f), Quaternion.identity);
             }
         }

       



        /*for (int i = -10; i < totalCol; i++)                      fills emmpty cells around the gameboard with obstacles.
        {
            for (int j = -10; j < totalRow; j++)
            {
                if(i >= columns || j >= rows || i < 0 || j < 0)
                {
                    Instantiate(ground, new Vector3(i, j, 0f), Quaternion.identity);
                    Instantiate(obstacle, new Vector3(i, j, 0f), Quaternion.identity);
                }
            }
        }*/
    }

    public void putObjectsOnMap(GameObject objectToPut,List<Vector3> positionsToPut)
    {
        if(positionsToPut != null)
        {
            for (int i = 0; i < positionsToPut.Count; i++)
            {
                Instantiate(objectToPut, positionsToPut[i], Quaternion.identity);
            }
        }
        
    }

    
    
    public void LevelCreator(int level)
    {
        Debug.Log("Level = " + level);
        levelManager.LevelData(level);

        
        columns = levelManager.columns;
        rows = levelManager.rows;
        dogPos = levelManager.dogPos;
        playerPos = levelManager.playerPos;
        obstaclepos = levelManager.obstaclepos;
        exitPos = levelManager.exitPos;
        levelColorCode = levelManager.levelColorCode;

        DataScript.expectedBoneCount = levelManager.boneCount;
        DataScript.boneCount = 0;
        DataScript.levelColorCode = levelColorCode;
        

        pooledBoneList = ObjectPooler.instance.PooltheObjects(bone,rows * columns);
        putObjectsOnMap(dog, dogPos);
        putObjectsOnMap(bore, playerPos);
        putObjectsOnMap(obstacle, obstaclepos);
        Instantiate(exit, exitPos, Quaternion.identity);
        InitializeList();

        cameraScript.setCameraPosition(columns,rows);
    }

}
