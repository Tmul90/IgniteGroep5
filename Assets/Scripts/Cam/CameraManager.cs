using System;
using UnityEngine;
using Util;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform spawnPointLookat;

    private void Start()
    {
        SetCameraLocation(spawnPoint);
        CameraLookAt(spawnPointLookat);
    }

    public void CameraLookAt(Transform target) => cam.transform.LookAt(target);
    
    public void SetCameraLocation(Transform target) => cam.transform.position = target.position;
}
