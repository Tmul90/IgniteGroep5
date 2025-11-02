using System;
using TMPro;
using UnityEngine;

public class Evidence : MonoBehaviour
{
    [SerializeField] private EvidenceScriptableObject evidenceScriptableObject;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    [SerializeField] private EvidenceManager evidenceManager;

    private string evidenceName;
    private string evidenceText;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ApplyData();
    }

    private void ApplyData()
    {
        evidenceName = evidenceScriptableObject.evidenceName;
        evidenceText = evidenceScriptableObject.evidenceText;
        
        spriteRenderer.sprite = evidenceScriptableObject.evidenceSprite;
    }

    private void OnMouseDown()
    {
        EvidenceManager.OpenEvidencePopup(evidenceText, evidenceName, evidenceScriptableObject);
    }
}
