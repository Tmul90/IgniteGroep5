using Dialogue;
using NPC;
using UnityEngine;
using UnityEngine.UI;
using Util;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] private Texture2D npcSprite; 
    [SerializeField] private Image playerSprite; 
    [SerializeField] private Text dialogueText; 
    
    /// <summary>
    /// Retrieves all Dialogues at the awake step
    /// </summary>
    private new void Awake() => RetrieveAllDialogues();

    /// <summary>
    /// Searches the Resource/Dialogues folder for any TextAsset files and adds them to the Dictionary in the form of DialogueData
    /// </summary>
    private void RetrieveAllDialogues()
    {
        var dialogueFiles = Resources.LoadAll<TextAsset>("Dialogues");

        foreach (var file in dialogueFiles)
        {
            var entry = JsonUtility.FromJson<DialogueData>(file.text);
            DialogueLibrary._dialogueDict.Add(entry.id, entry);
        }
    }

    /// <summary>
    /// Returns a DialogueData from the Resources folder with the given ID
    /// </summary>
    /// <param name="id">The id of the dialogue</param>
    /// <returns>The DialogueData Containing the Dialogue</returns>
    public DialogueData GetDialogueDataById(string id)
    {
        if (DialogueLibrary._dialogueDict.TryGetValue(id, out var entry))
        {
            Debug.LogWarning($"Retrieved '{DialogueLibrary._dialogueDict.Count}' dialogues.'");
            return entry;
        }
        
        Debug.LogWarning($"Dialogue with ID '{id}' not found.");
        return null;
    }

    public void StartDialogue(NpcObject currentNpc, string dialogueId)
    {
        npcSprite = currentNpc.npcSprite.texture;

        var dialogueData = GetDialogueDataById(dialogueId);
    }

    public void GenerateDialogueText(Color npcColor, DialogueData dialogueData)
    {
        
        dialogueText.text = dialogueData.dialogues[0];
    }
}
