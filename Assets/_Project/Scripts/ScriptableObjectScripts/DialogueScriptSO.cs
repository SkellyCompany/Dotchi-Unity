using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct DialogueSentence
{
    [TextArea(5, 20)]
    public string text;
    public float waitTime;
}

[Serializable]
public struct DialogueScript
{
    public string dialogueName;
    public List<DialogueSentence> dialogueSentences;
}


[CreateAssetMenu(fileName = "Dialogue Script", menuName = "Scriptable Objects/Dialogue Script", order = 1)]
public class DialogueScriptSO : ScriptableObject
{
    public List<DialogueScript> dialogueSentences = new List<DialogueScript>();

    public DialogueScript DialogueScript(string dialogueName)
    {
        for (int i = 0; i < dialogueSentences.Count; i++)
        {
            if (dialogueSentences[i].dialogueName.Equals(dialogueName))
            {
                return dialogueSentences[i];
            }
        }
        return dialogueSentences[0];
    }
}
