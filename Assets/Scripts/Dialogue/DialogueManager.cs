using System;
using System.Collections.Generic;
using Dialogue;
using NPC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Util;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] private RawImage npcSpriteContainer; 
    [SerializeField] private TMP_Text dialogueTextPrefab;
    
    [SerializeField] private Transform buttonContainer;
    [SerializeField] private GameObject buttonPrefab;
    
    [SerializeField] private GameObject DialoguePopup;
    
    [SerializeField] private Transform dialogueTextSpawnLocation;
    
    [SerializeField] private RawImage background;
    [SerializeField] private RawImage npcNamePlate;

    private NpcObject currentNpcRef;
    private int currentLineIndex;
    private DialogueData currentDialogueDataRef;
    private bool dialogueHasStarted;
    private TMP_Text dialogueText;
    private List<GameObject> buttons = new List<GameObject>();
    private string originalId;

    /// <summary>
    /// Retrieves all Dialogues at the awake step
    /// </summary>
    private new void Awake()
    {
        DialoguePopup.SetActive(false);
        RetrieveAllDialogues();
    }

    private void Update()
    {
        if (dialogueHasStarted) if (Input.GetKeyDown(KeyCode.Space)) OnSpacePressed();
    }

    /// <summary>
    /// Searches the Resource/Dialogues folder for any TextAsset files and adds them to the Dictionary in the form of DialogueData
    /// </summary>
    private void RetrieveAllDialogues()
    {
        var dialogueFiles = Resources.LoadAll<TextAsset>("Dialogues");

        foreach (var file in dialogueFiles)
        {
            var entry = JsonUtility.FromJson<DialogueData>(file.text);
            DialogueLibrary._dialogueDict.TryAdd(entry.id, entry);
        }
    }

    /// <summary>
    /// Returns a DialogueData from the Resources folder with the given ID
    /// </summary>
    /// <param name="id">The id of the dialogue</param>
    /// <returns>The DialogueData Containing the Dialogue</returns>
    private DialogueData GetDialogueDataById(string id)
    {
        if (DialogueLibrary._dialogueDict.TryGetValue(id, out var entry))
        {
            Debug.LogWarning($"Retrieved '{DialogueLibrary._dialogueDict.Count}' dialogues.'");
            return entry;
        }
        
        Debug.LogWarning($"Dialogue with ID '{id}' not found.");
        return null;
    }

    private void OnSpacePressed()
    {
        if (currentDialogueDataRef == null) return;

        currentLineIndex++;

        if (currentLineIndex < currentDialogueDataRef.dialogues.Length)
        {
            GenerateDialogueText();
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        dialogueHasStarted = false;
        Destroy(dialogueText);
        CreateResponseButtons();
    }

    public void StartDialogue(NpcObject currentNpc, string dialogueId)
    {
        if (dialogueText != null) Destroy(dialogueText);
        dialogueText = Instantiate(dialogueTextPrefab, dialogueTextSpawnLocation).GetComponent<TMP_Text>();
        dialogueHasStarted = true;

        npcNamePlate.texture = currentNpc.npcNameImage.texture;
        
        npcSpriteContainer.texture = currentNpc.npcImage;
        
        DialoguePopup.SetActive(true);
        currentNpcRef = currentNpc;
        background.texture = currentNpc.npcBackground.texture;

        var dialogueData = GetDialogueDataById(dialogueId);
        currentDialogueDataRef = dialogueData;
        
        currentLineIndex = 0;

        GenerateDialogueText();
    }

    private void GenerateDialogueText()
    {
        dialogueText.text = currentDialogueDataRef.dialogues[currentLineIndex];
    }

    private void CreateResponseButtons()
    {
        for (int i = 0; i < currentDialogueDataRef.playerResponses.Length; i++)
        {
             var buttonPrefabInstance = Instantiate(buttonPrefab, buttonContainer);
            buttonPrefabInstance.name = currentDialogueDataRef.playerResponses[i];
            
            var newButton = buttonPrefabInstance.GetComponent<Button>();
        
            buttonPrefabInstance.GetComponentInChildren<TMP_Text>().text = currentDialogueDataRef.playerResponses[i];

            buttons.Add(buttonPrefabInstance);

            var index = i;
            newButton.onClick.AddListener(() =>
                {
                    StartDialogue(currentNpcRef, originalId + " " + index);
                    
                    foreach (var btn in buttons)
                        Destroy(btn);
                    buttons.Clear();
                }
            );
        }
        var endButtonInstance = Instantiate(buttonPrefab, buttonContainer);
        endButtonInstance.name = "EndDialogue";

        var endButton = endButtonInstance.GetComponent<Button>();
        endButtonInstance.GetComponentInChildren<TMP_Text>().text = "End Dialogue";

        buttons.Add(endButtonInstance);

        endButton.onClick.AddListener(() =>
        {
            DialoguePopup.SetActive(false);

            // Destroy all buttons
            foreach (var btn in buttons)
            {
                if (btn != null)
                    Destroy(btn);
            }
            buttons.Clear();
        });
    }

    public void SetOriginalDialogueId(string id) => originalId = id;
}
