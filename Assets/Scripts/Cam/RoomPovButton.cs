using System;
using Unity.VisualScripting;
using UnityEngine;

public class RoomPovButton : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private CameraManager camManager;

    private void OnMouseDown()
    {
        MapButton._map.transform.position = MapButton._mapIdleTarget.position;
        camManager.CameraLookAt(target);
    }
}
