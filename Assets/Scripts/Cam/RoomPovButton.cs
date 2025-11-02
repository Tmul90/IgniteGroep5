using System;
using Unity.VisualScripting;
using UnityEngine;

public class RoomPovButton : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private CameraManager camManager;

    private void OnMouseDown() => camManager.CameraLookAt(target);
}
