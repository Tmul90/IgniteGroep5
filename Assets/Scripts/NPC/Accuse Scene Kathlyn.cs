using System;
using System.Linq;
using NPC;
using UnityEngine;

public class AccuseSceneDialogues : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    
    [SerializeField] private NpcObject kathlynNpc;
    [SerializeField] private NpcObject diegoNpc;
    [SerializeField] private NpcObject graceNpc;
    [SerializeField] private NpcObject joseNpc;


    public void StartAccuseSceneKathlyn()
    {
        var dialogue = dialogueManager.GetDialogueDataById("KaitlynAccuse 1");
        if (!EvidenceInventory.evidenceInventory.ContainsKey("Files"))
        {
            if (dialogue.playerResponses != null && dialogue.playerResponses.Length > 0)
            {
                var responses = dialogue.playerResponses.ToList();
                responses.RemoveAt(responses.Count - 1); // Remove the last response
                dialogue.playerResponses = responses.ToArray();
            }
        }
        dialogueManager.StartDialogue(kathlynNpc, "KaitlynAccuse 1", dialogue, true);
        
    }
    
    public void StartAccuseSceneGrace()
    {
        var dialogue = dialogueManager.GetDialogueDataById("GraceAccuse 1");
        if (!EvidenceInventory.evidenceInventory.ContainsKey("Pills"))
        {
            if (dialogue.playerResponses != null && dialogue.playerResponses.Length > 0)
            {
                var responses = dialogue.playerResponses.ToList();
                responses.RemoveAt(responses.Count - 1); // Remove the last response
                dialogue.playerResponses = responses.ToArray();
            }
        }
        dialogueManager.StartDialogue(graceNpc, "GraceAccuse 1", dialogue, true);
    }

    public void StartAccuseSceneJose()
    {
        var dialogue = dialogueManager.GetDialogueDataById("JoseAccuse 1");
        if (!EvidenceInventory.evidenceInventory.ContainsKey("Keys"))
        {
            if (dialogue.playerResponses != null && dialogue.playerResponses.Length > 0)
            {
                var responses = dialogue.playerResponses.ToList();
                responses.RemoveAt(responses.Count - 1); // Remove the last response
                dialogue.playerResponses = responses.ToArray();
            }
        }
        dialogueManager.StartDialogue(joseNpc, "JoseAccuse 1", dialogue, true);
    }

    public void StartAccuseSceneDiego()
    {
        var dialogue = dialogueManager.GetDialogueDataById("DiegoAccuse 1");
        if (!EvidenceInventory.evidenceInventory.ContainsKey("Pregnancy Test"))
        {
            if (dialogue.playerResponses != null && dialogue.playerResponses.Length > 0)
            {
                var responses = dialogue.playerResponses.ToList();
                responses.RemoveAt(responses.Count - 1); // Remove the last response
                dialogue.playerResponses = responses.ToArray();
            }
        }
        dialogueManager.StartDialogue(diegoNpc, "DiegoAccuse 1", dialogue, true);
    }
}
