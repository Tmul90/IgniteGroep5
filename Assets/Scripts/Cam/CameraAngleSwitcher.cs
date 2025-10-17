using UnityEngine;
using UnityEngine.UI;

namespace Cam
{
    public class CameraAngleSwitcher : MonoBehaviour
    {
        [SerializeField] private Image display; // UI img die gedisplayed word

        [SerializeField] private Sprite[] angles; // verschillende hoeken van de kamer

        [SerializeField] private int currentAngle = 0; // currente hoek
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            UpdateView();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A)) // 1 hoek terug
            {
                ChangeAngle(-1);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                ChangeAngle(1);
            }
        }

        private void ChangeAngle(int direction)
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

        private void UpdateView()
        {
            display.sprite = angles[currentAngle];
        }
    }
}
