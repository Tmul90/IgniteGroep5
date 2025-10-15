using UnityEngine;

namespace NPC
{
    [CreateAssetMenu(fileName = "NPCObject", menuName = "ScriptableObjects/NPCScriptableObject", order = 2)]
    public class NPCScriptableObject : ScriptableObject
    {
        public string npcName;   // The name of the NPC
        public Sprite npcSprite; // The Sprite/Model of the NPC
    }
}
