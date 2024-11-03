using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public string team ;
    public CameraСontroller cameraСontroller ;
    public Camera Camera ;
    public GameObject mapTerrain ;
    void Start()
    {
        gameObject.AddComponent<CameraСontroller>();
        cameraСontroller.cam = (gameObject.GetComponent<Camera>() == Camera.main) ? gameObject.GetComponent<Camera>() : throw new ArgumentException();
        cameraСontroller.mapBoundaryObject = GameObject.FindGameObjectWithTag("MapTerrain");
        team = "Team1";
    }

    void Update()
    {

    }

}
