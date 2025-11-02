using System;
using UnityEngine;

public class MapOpener : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private GameObject map;

    private void OnMouseDown()
    {
        map.transform.position = spawnPoint.position;       
    }
}
