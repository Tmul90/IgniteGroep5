using System.Collections.Generic;
using UnityEngine;
using Util;

public class DialogueManager : Singleton<DialogueManager>
{
    private Dictionary<string, DialogueData> dialogueDict = new(); // Dictionary with the first value the Dialogue ID and the second the DialogueData

    /// <summary>
    /// Retrieves all Dialogues at the awake step
    /// </summary>
    private void Awake() => RetrieveAllDialogues();

    /// <summary>
    /// Searches the Resource/Dialogues folder for any TextAsset files and adds them to the Dictionary in the form of DialogueData
    /// </summary>
    private void RetrieveAllDialogues()
    {
        TextAsset[] _dialogueFiles = Resources.LoadAll<TextAsset>("Dialogues");

        foreach (TextAsset file in _dialogueFiles)
        {
            var entry = JsonUtility.FromJson<DialogueData>(file.text);
            dialogueDict.Add(entry.id.ToString(), entry);
        }
    }

    /// <summary>
    /// Returns a DialogueData from the Resources folder with the given ID
    /// </summary>
    /// <param name="id">The id of the dialogue</param>
    /// <returns>The DialogueData Containing the Dialogue</returns>
    public DialogueData GetDialogueById(string id)
    {
        if (dialogueDict.TryGetValue(id, out DialogueData entry))
        {
            Debug.LogWarning($"Retrieved '{dialogueDict.Count}' dialogues.'");
            return entry;
        }
        
        Debug.LogWarning($"Dialogue with ID '{id}' not found.");
        return null;
    }
}
