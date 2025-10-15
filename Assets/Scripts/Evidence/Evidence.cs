using System;
using UnityEngine;

namespace Evidence
{
    [CreateAssetMenu(fileName = "Evidence", menuName = "ScriptableObjects/Evidence", order = 1)]
    public class Evidence : ScriptableObject
    {
        public string evidenceName;   // The name/title of the piece of evidence
        public Sprite evidenceSprite; // The Sprite/Model of the evidence
        public int evidenceID;        // potentially the ID tag the evidence uses for coding reason remove if not necessary
    }
}
