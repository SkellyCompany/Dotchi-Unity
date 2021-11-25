using Demonics.Sounds;
using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private DialogueScriptSO[] _dialogueScripts = default;
    [SerializeField] private TextMeshProUGUI _dialogueText = default;
    private Audio _audio;
    private DialogueScript _dialogueScript;
    private int _currentDialogueSentenceIndex;


    void Awake()
    {
        _audio = GetComponent<Audio>();
    }

    public void StartDialogue(string node)
    {
        _currentDialogueSentenceIndex = 0;
        _dialogueScript = _dialogueScripts[0].DialogueScript(node);
        StartCoroutine(WriteDialogueCoroutine());
    }

    private void NextSentence()
	{
        StartCoroutine(WriteDialogueCoroutine());
    }

	IEnumerator WriteDialogueCoroutine()
    {
        _dialogueText.text = "";
        _dialogueText.color = Color.white;
        if (_currentDialogueSentenceIndex + 1 < _dialogueScript.dialogueSentences.Count)
        {
            yield return new WaitForSeconds(0.5f);
            DialogueSentence dialogueSentence = _dialogueScript.dialogueSentences[_currentDialogueSentenceIndex];
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
                _dialogueText.text = string.Concat(_dialogueText.text, dialogueSentence.text[i]);
                yield return new WaitForSeconds(0.1f);
            }
            float elapsedTime = 0.0f;
            float waitTime = 1.0f;
            Color startColor = _dialogueText.color;
            Color endColor = new Color(1.0f,1.0f,1.0f,0.0f);
            while (elapsedTime < waitTime)
            {
                _dialogueText.color = Color.Lerp(startColor, endColor, elapsedTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(0.5f);
            NextSentence();
            _currentDialogueSentenceIndex++;
        }
    }
}
