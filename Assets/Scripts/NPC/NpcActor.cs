using System;
using NPC;
using UnityEngine;

public class NpcActor : MonoBehaviour
{
    [SerializeField] private NpcObject npcScriptableObject;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private DialogueManager dialogueManager;
    
    private string npcName;
    private Color npcColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ApplyData();
    }

    private void ApplyData()
    {
        npcName = npcScriptableObject.npcName;
        npcColor = npcScriptableObject.npcColor;
        spriteRenderer.sprite = npcScriptableObject.npcSprite;
    }

    private void OnMouseDown()
    {
        dialogueManager.StartDialogue(npcScriptableObject, npcName + " 1");
        dialogueManager.SetOriginalDialogueId(npcName + " 1");
    }
}
