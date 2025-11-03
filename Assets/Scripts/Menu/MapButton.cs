using UnityEngine;

public class MapButton : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform mapIdleTarget;
    [SerializeField] private CameraManager camManager;
    [SerializeField] private GameObject map;

    private void OnMouseDown()
    {
        camManager.SetCameraLocation(target);
        map.transform.position = mapIdleTarget.position;
    }
}
