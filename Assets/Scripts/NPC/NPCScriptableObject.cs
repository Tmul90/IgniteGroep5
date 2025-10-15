using UnityEngine;

namespace NPC
{
    [CreateAssetMenu(fileName = "NPCObject", menuName = "ScriptableObjects/NPCScriptableObject", order = 2)]
    public class NPCScriptableObject : ScriptableObject
    {
        public string npcName;
        public Sprite npcSprite;
    }
}
