using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera camera;

    
    void Start()
    {
        camera = Camera.main;
    }

    public void setCameraPosition(int column, int row)
    {
        float x = column / 2;
        float y = row / 2;
        float z = -(x + y) / 2;
        camera.transform.position = new Vector3(x, y, z);
    }
}
