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
    
    [SerializeField] private MenuManager kathlynManager;
    [SerializeField] private MenuManager graceManager;
    [SerializeField] private MenuManager joseManager;
    [SerializeField] private MenuManager diegoManager;

    private NpcObject currentNpcRef;
    private int currentLineIndex;
    private DialogueData currentDialogueDataRef;
    private bool dialogueHasStarted;
    private TMP_Text dialogueText;
    private List<GameObject> buttons = new List<GameObject>();
    private string originalId;
    private bool _isAccuseScene;

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

    public void StartDialogue(NpcObject currentNpc, string dialogueId, DialogueData dialogueData, bool isAccuseScene)
    {
        dialogueHasStarted = true;
        
        InitializeDialogue(currentNpc, dialogueId, dialogueData, isAccuseScene);
        
        if (dialogueText != null) Destroy(dialogueText);
        dialogueText = Instantiate(dialogueTextPrefab, dialogueTextSpawnLocation).GetComponent<TMP_Text>();
        
        DialoguePopup.SetActive(true);
        
        currentLineIndex = 0;

        GenerateDialogueText();
    }
    
    private void InitializeDialogue(NpcObject currentNpc, string dialogueId, DialogueData dialogueData, bool isAccuseScene)
    {
        _isAccuseScene = isAccuseScene;
        originalId = dialogueId;
        npcNamePlate.texture = currentNpc.npcNameImage.texture;
        npcSpriteContainer.texture = currentNpc.npcImage;
        currentNpcRef = currentNpc;
        background.texture = currentNpc.npcBackground.texture;
        currentDialogueDataRef = dialogueData;
    }

    private void GenerateDialogueText() => 
        dialogueText.text = currentDialogueDataRef.dialogues[currentLineIndex];
    
    private void CreateResponseButtons()
    {
        var hasResponses = currentDialogueDataRef.playerResponses != null && currentDialogueDataRef.playerResponses.Length > 0;

        if (_isAccuseScene && !hasResponses)
        {
            var accuseButtonInstance = Instantiate(buttonPrefab, buttonContainer);
            accuseButtonInstance.name = "AccuseButton";

            var accuseButton = accuseButtonInstance.GetComponent<Button>();
            accuseButtonInstance.GetComponentInChildren<TMP_Text>().text = "Accuse";

            buttons.Add(accuseButtonInstance);

            accuseButton.onClick.AddListener(() =>
            {
                DialoguePopup.SetActive(false);
                ClearButtons();

                var manager = GetManagerForCurrentNpc();
                if (manager != null)
                    manager.PlayGame();
                else
                    Debug.LogWarning("No MenuManager found for current NPC!");
            });

            return;
        }
        
        if (hasResponses)
        {
            for (int i = 0; i < currentDialogueDataRef.playerResponses.Length; i++)
            {
                var buttonPrefabInstance = Instantiate(buttonPrefab, buttonContainer);
                buttonPrefabInstance.name = currentDialogueDataRef.playerResponses[i];

                var newButton = buttonPrefabInstance.GetComponent<Button>();
                buttonPrefabInstance.GetComponentInChildren<TMP_Text>().text = currentDialogueDataRef.playerResponses[i];

                buttons.Add(buttonPrefabInstance);

                var index = i;
                var nextDialogueData = GetDialogueDataById(originalId + " " + index);

                newButton.onClick.AddListener(() =>
                {
                    // Start next dialogue
                    StartDialogue(currentNpcRef, originalId + " " + index, nextDialogueData, _isAccuseScene);
                    ClearButtons();
                });
            }
        }
        
        if (!_isAccuseScene)
        {
            var endButtonInstance = Instantiate(buttonPrefab, buttonContainer);
            endButtonInstance.name = "EndDialogue";

            var endButton = endButtonInstance.GetComponent<Button>();
            endButtonInstance.GetComponentInChildren<TMP_Text>().text = "End Dialogue";

            buttons.Add(endButtonInstance);

            endButton.onClick.AddListener(() =>
            {
                DialoguePopup.SetActive(false);
                ClearButtons();
            });
        }

        return;

        void ClearButtons()
        {
            foreach (var btn in buttons)
                if (btn != null)
                    Destroy(btn);
            buttons.Clear();
        }
    }


    
    private MenuManager GetManagerForCurrentNpc()
    {
        if (currentNpcRef == null)
        {
            Debug.LogWarning("No current NPC reference found.");
            return null;
        }

        var npcName = currentNpcRef.npcName;

        switch (npcName)
        {
            case "Kaitlyn":
                return kathlynManager;
            case "Grace":
                return graceManager;
            case "Jose":
                return joseManager;
            case "Diego":
                return diegoManager;
            default:
                Debug.LogWarning($"No MenuManager found for NPC name: {npcName}");
                return null;
        }
    }

    public void SetOriginalDialogueId(string id) => originalId = id;
}
