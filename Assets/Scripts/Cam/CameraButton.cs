using UnityEngine;



namespace Cam
{
    public class CameraButton : MonoBehaviour
    {
        [SerializeField] private HallCam hallwayManager; // The central hallway manager
        [SerializeField] private GameObject cameraPrefab;        // The prefab to open when pressed
        

        public void OnClick()
        {
            if (hallwayManager != null && cameraPrefab != null)
            {
                hallwayManager.OpenCamera(cameraPrefab);
                
            }
        }
        
    }
}