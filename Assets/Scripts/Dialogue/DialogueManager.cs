using UnityEngine;
using Util;

public class DialogueManager : Singleton<DialogueManager>
{
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
}
