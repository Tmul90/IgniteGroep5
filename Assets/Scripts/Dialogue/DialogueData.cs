using System;

[Serializable]
public class DialogueData
{
    public string id;                 // The Dialogue ID (Example the first dialogue would be 1, and you'd have two choices so the ones after are 1.1 and 1.2)
    public string[] dialogues;       // The Dialogues the NPC says
    public string[] playerResponses; // The responses the player can give
}
