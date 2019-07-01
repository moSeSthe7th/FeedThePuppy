using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraScript : MonoBehaviour
{   
    Camera mCamera;
    float camSize;
    public Vector3 camSizeMapper;

    public Material pinkSkybox;
    public Material blueSkybox;

    private Material skyboxMaterial;

    string skyBoxPathStr;
    
    void Start()
    {
        mCamera = Camera.main;
        camSize = mCamera.orthographicSize;

        camSizeMapper = new Vector3(camSize,camSize,camSize);
    }

    //Moved skoybox settings to SetCamera because of script execution order. This works as a work around could be updated
    private void LateUpdate()
    {
        if(DataScript.skyboxPath != null || Equals(skyBoxPathStr,DataScript.skyboxPath) == false)
        {
            skyBoxPathStr = DataScript.skyboxPath;
            skyboxMaterial = Resources.Load<Material>(skyBoxPathStr);
            RenderSettings.skybox = skyboxMaterial;
        }
    }

    public void SetCamera(float column, float row , float newCamSize)
    {
        //Changed int with float value must be increase 0.5 by 0.5. 

        float x = (column - 1f) / 2f;
        float y = (row - 1f) / 2f;
        float z = -(x + y) / 2f;

        mCamera.transform.position = new Vector3(x, y, z);

        mCamera.orthographicSize = newCamSize;

    }
}
