using UnityEngine;
using UnityEngine.UI;
namespace Cam
{
    public class HallCam : MonoBehaviour
    {
        [SerializeField] private Transform uiParent; // Canvas Reference
        
        private GameObject activeCamera;
        
        public Image ImageDisplayGameObject;
        public Sprite ImageToActive;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) // destroy vorige instance en laat main hall zien
            {
                ShowImage();
                Destroy(activeCamera); // destroyed vorige instance van de image prefabs
            }
        }

        public void OpenCamera(GameObject cameraPrefab) // opent de camera en neemt zijn references mee en als er al een camera is dan destroyed hij die eerst.
        {
            if (activeCamera != null)
            {
                Destroy(activeCamera);
            }

            activeCamera = Instantiate(cameraPrefab, uiParent);
        }

     
        
        public void ShowImage()
        {
            ImageDisplayGameObject.sprite = ImageToActive;
        }
    }
}