using System;
using UnityEngine;

namespace Evidence
{
    [CreateAssetMenu(fileName = "Evidence", menuName = "ScriptableObjects/Evidence", order = 1)]
    public class Evidence : ScriptableObject
    {
        public string evidenceName;
        public Sprite evidenceSprite;
        public int evidenceID;
    }
}
