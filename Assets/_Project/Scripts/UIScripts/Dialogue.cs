using Demonics.Sounds;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private DialogueScriptSO[] _dialogueScripts = default;
    private Audio _audio;
    private DialogueScript _dialogueScript;
    private int _currentDialogueSentence;
    private bool _isDialogueRunning;


    void Awake()
    {
        _audio = GetComponent<Audio>();
    }

    public virtual void StartDialogue(string node)
    {
        _isDialogueRunning = true;
        _currentDialogueSentence = 0;
        //_dialogueScript = _dialogueScriptSO.DialogueScript(node);
        StartCoroutine(WriteDialogueCoroutine());
    }

    //protected virtual void NextSentence()
    //{
    //    _writingDialogueCoroutine = StartCoroutine(WriteDialogueCoroutine());
    //}

    IEnumerator WriteDialogueCoroutine()
    {
       // _dialogueText.text = "";
        if (_currentDialogueSentence < _dialogueScript.dialogueSentences.Count)
        {
            yield return new WaitForSeconds(0.5f);
            DialogueSentence dialogueSentence = _dialogueScript.dialogueSentences[_currentDialogueSentence];
            for (int i = 0; i < dialogueSentence.text.Length; i++)
            {
                Sound sound = _audio.Sound("Typing");
                if (sound != null)
                {
                    sound.Play();
                }
                else
                {
                    _audio.Sound3D("Typing").Play();
                }
                //_dialogueText.text = string.Concat(_dialogueText.text, dialogueSentence.text[i]);
                //yield return new WaitForSeconds(_textUpdateTime);
            }
            //SentenceEnd();
            _currentDialogueSentence++;
        }
        else
        {
            //DialogueEnd();
        }
    }
}
