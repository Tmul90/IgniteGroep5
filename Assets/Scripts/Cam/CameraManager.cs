using UnityEngine;
using Util;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] private Camera cam;

    public void CameraLookAt(Transform target) => cam.transform.LookAt(target);
    
    public void SetCameraLocation(Transform target) => cam.transform.position = target.position;
}
