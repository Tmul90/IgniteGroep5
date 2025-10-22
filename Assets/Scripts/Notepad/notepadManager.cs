using TMPro;
using UnityEngine;

namespace Notepad
{
    public class NotepadManager : MonoBehaviour
    {
        [SerializeField] private GameObject notepadUI;                      // The notepad panel op de rechterkant van het scherm
        [SerializeField] private TMP_InputField inputField;                 // The text input field voor notes
        [SerializeField] private KeyCode openNotePad = KeyCode.UpArrow;     // The button needed to open the notepad

        private bool _isOpen;                                               // Let op of notepad open is

        private void Start() => 
            notepadUI.SetActive(false);
        
        private void Update() =>
            ToggleNotepad();

        /// <summary>
        /// Toggles the Notepad on and off
        /// </summary>
        private void ToggleNotepad()
        {
            if (!Input.GetKeyDown(openNotePad)) return;
            _isOpen = !_isOpen;
            notepadUI.SetActive(_isOpen);

            if (_isOpen)
                OpenNotepad();
            else
                CloseNotepad();
        }

        /// <summary>
        /// opens the notepad by activating the ui asset and activates the ability to select and type in it
        /// </summary>
        private void OpenNotepad()
        {
            inputField.ActivateInputField();
            inputField.Select();
        }

        /// <summary>
        /// Closes the notepad by deactivating the ui asset
        /// </summary>
        private void CloseNotepad() => inputField.DeactivateInputField();
        
    }
}