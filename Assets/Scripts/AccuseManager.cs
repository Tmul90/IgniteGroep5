using System;
using UnityEngine;
using UnityEngine.UI;

public class AccuseManager : MonoBehaviour
{
    [SerializeField] private GameObject AccuseMenu;

    [SerializeField] private Transform ButtonPanel;
    [SerializeField] private GameObject ButtonPrefab;

    private void Start()
    {
        CloseAccuseMenu();
    }

    private void Update()
    {
        if (EvidenceInventory.evidenceInventory.Count == 3)
        {
            var secretEndingButton = Instantiate(ButtonPrefab, ButtonPanel);
            var button = secretEndingButton.GetComponent<Button>();
            button.onClick.AddListener(() => GoToSecretEnding());
        }
    }

    public void OpenAccuseMenu() => AccuseMenu.SetActive(true);
    public void CloseAccuseMenu() => AccuseMenu.SetActive(false);

    public void GoToSecretEnding(){} // insert hier code die speler naar secret ending stuurt

    // insert hier alle redirection knop code en link ze in scene
}
