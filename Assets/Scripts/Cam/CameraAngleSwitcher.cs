using UnityEngine;
using UnityEngine.UI;

namespace Cam
{
    public class CameraAngleSwitcher : MonoBehaviour
    {
        private Image display; // UI img die gedisplayed word

        [SerializeField] private Sprite[] angles; // verschillende hoeken van de kamer

        [SerializeField] private int currentAngle = 0; // currente hoek
        
        void Awake()
        {
            if (display == null) // zoekt voor object met de tag roomcam om de images aan door te geven
            {
                GameObject taggedObject = GameObject.FindGameObjectWithTag("RoomCam");
                if (taggedObject != null)
                {
                    display = taggedObject.GetComponent<Image>();
                }
                else
                {
                    Debug.LogWarning("CameraAngleSwitcher: Geen object met tag 'RoomCam' gevonden in de scene");
                }
            }
            UpdateView();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A)) // 1 hoek terug
            {
                ChangeAngle(-1);
            }
            if (Input.GetKeyDown(KeyCode.D)) // 1 hoek vooruit
            {
                ChangeAngle(1);
            }
        }

        private void ChangeAngle(int direction) // veranderd camera hoek
        {
            currentAngle += direction;
            if (currentAngle < 0)
            { 
                currentAngle = angles.Length - 1;
            }
            else if (currentAngle >= angles.Length)
            {
                currentAngle = 0;
            }
            UpdateView();
        }

        private void UpdateView() // veranderd de image naar de index nummer
        {
            display.sprite = angles[currentAngle];
        }
    }
}
