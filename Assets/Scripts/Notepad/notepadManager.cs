using UnityEngine;
using TMPro;

namespace UI
{
    public class NotepadManager : MonoBehaviour
    {
        [SerializeField] private GameObject notepadUI;   // The notepad panel op de rechterkant van het scherm
        [SerializeField] private TMP_InputField inputField; // The text input field voor notes

        private bool _isOpen = false; // Let op of notepad open is

        private void Start() => notepadUI.SetActive(false);
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) // checked voor input
                ToggleNotepad(); // Toggled Notepad open/dicht

            if (_isOpen && Input.GetKeyDown(KeyCode.Escape))
                ToggleNotepad();
        }

        private void ToggleNotepad()
        {
            // logica voor open en dicht doen
            _isOpen = !_isOpen;
            notepadUI.SetActive(_isOpen);

            if (_isOpen)
                OpenNotepad();
            else
                CloseNotepad();
        }

        private void OpenNotepad()
        {
            //Activate de input van de toetsen
            inputField.ActivateInputField();
            inputField.Select();
        }

        private void CloseNotepad() => inputField.DeactivateInputField();
        
    }
}