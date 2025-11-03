using System;
using TMPro;
using UnityEngine;

public class EvidenceManager : MonoBehaviour
{
    [SerializeField] private TMP_Text evidenceTextElement;
    [SerializeField] private GameObject evidencePopup;
    [SerializeField] private GameObject evidenceInventory;
    
    private static TMP_Text _evidenceTextElement;
    private static GameObject _evidencePopup;
    private static GameObject _evidenceInventory;

    private void Start()
    {
        _evidenceTextElement = evidenceTextElement;
        _evidencePopup = evidencePopup;
        _evidenceInventory = evidenceInventory;
        _evidencePopup.SetActive(false);
        evidenceInventory.SetActive(false);
    }

    public static void OpenEvidencePopupViaInventory(string evidenceText, string evidenceName, EvidenceScriptableObject evidenceScriptableObject)
    {
        OpenEvidencePopup(evidenceText, evidenceName, evidenceScriptableObject);
        _evidenceInventory.SetActive(false);
    }

    public static void OpenEvidencePopup(string evidenceText, string evidenceName, EvidenceScriptableObject evidenceScriptableObject)
    {
        _evidencePopup.SetActive(true);
        _evidenceTextElement.text = evidenceText;
        print(evidenceName);
        
        EvidenceInventory.AddEvidence(evidenceName, evidenceScriptableObject);
    }
    
    public void CloseEvidence() => evidencePopup.SetActive(false);

    public void OpenEvidenceInventory() => evidenceInventory.SetActive(true);
    
    public void CloseEvidenceInventory() => evidenceInventory.SetActive(false);
}
