using System;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class EvidenceInventory : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform buttonContainer;
    
    private static GameObject _buttonPrefab;
    private static Transform _buttonContainer;
    
    [SerializeField] private EvidenceManager evidenceManager;
    
    public static Dictionary<string, EvidenceScriptableObject> evidenceInventory = new Dictionary<string, EvidenceScriptableObject>();

    private void Start()
    {
        _buttonPrefab = buttonPrefab;
        _buttonContainer = buttonContainer;
    }

    public static void AddEvidence(string evidenceName, EvidenceScriptableObject evidence)
    {
        if (evidenceInventory.ContainsKey(evidenceName)) return;
        
        evidenceInventory.Add(evidenceName, evidence);
        CreateButton(evidenceName);
    }

    private static void CreateButton(string evidenceName)
    {
        var newButtonObj = Instantiate(_buttonPrefab, _buttonContainer);
        newButtonObj.name = evidenceName;
        
        var newButton = newButtonObj.GetComponent<Button>();
        
        newButtonObj.GetComponentInChildren<TMP_Text>().text = evidenceName;
        
        evidenceInventory.TryGetValue(evidenceName, out var entry);
        
        newButton.onClick.AddListener(() => EvidenceManager.OpenEvidencePopupViaInventory(entry.evidenceText, entry.evidenceName, entry));
    }
}
