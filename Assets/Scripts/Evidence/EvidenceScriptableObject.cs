using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Evidence", menuName = "ScriptableObjects/Evidence", order = 1)] 
public class EvidenceScriptableObject : ScriptableObject 
{ 
    public string evidenceName;   // The name/title of the piece of evidence
    public Sprite evidenceSprite; // The Sprite/Model of the evidence
    public int evidenceID;        // potentially the ID tag the evidence uses for coding reason remove if not necessary
    public string evidenceText;   // Text that will pop up when the evidence is clicked
}

