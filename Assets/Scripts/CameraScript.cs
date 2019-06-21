using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraScript : MonoBehaviour
{
    public Camera camera;

    public Material pinkSkybox;
    public Material blueSkybox;

    private Material skyboxMaterial;
    
    void Start()
    {
        camera = Camera.main;
        //camera.backgroundColor = DataScript.backgroundColor;
        skyboxMaterial = Resources.Load<Material>(DataScript.skyboxPath);
        RenderSettings.skybox = skyboxMaterial;
    }

    public void setCameraPosition(int column, int row)
    {
        float x = column / 2;
        float y = row / 2;
        float z = -(x + y) / 2;
        camera.transform.position = new Vector3(x, y, z);
    }
}
