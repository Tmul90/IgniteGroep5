using System;
using UnityEngine;

public class MapButton : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] public Transform mapIdleTarget;
    [SerializeField] private CameraManager camManager;
    [SerializeField] public GameObject map;
    
    public static GameObject _map;
    public static Transform _mapIdleTarget;

    private void Start()
    {
        _map = map;
        _mapIdleTarget = mapIdleTarget;
    }

    private void OnMouseDown()
    {
        camManager.SetCameraLocation(target);
        map.transform.position = mapIdleTarget.position;
    }
}
