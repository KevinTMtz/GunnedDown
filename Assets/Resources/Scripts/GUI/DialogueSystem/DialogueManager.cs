using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    private Queue<string> sentences;

    private GameObject dialoguePanel;
    private Text dialoguePanelText;
    private HorizontalLayoutGroup panelChildComponent;

    private bool isActive;

    private bool isWriting;
    private bool isWritingStop;

    void Start() {
        sentences = new Queue<string>();
        dialoguePanel = FindObjectOfType<PlayerGUI>().DialoguePanel;
        dialoguePanelText = dialoguePanel.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        panelChildComponent = dialoguePanel.transform.GetChild(0).GetComponent<HorizontalLayoutGroup>();

        isWritingStop = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.V) && isActive && !isWriting) {
            DisplayNextSentence();
        } else if (Input.GetKeyDown(KeyCode.V) && isActive && isWriting) {
            isWritingStop = true;
        }
    }

    public void StartDialogue(Dialogue dialogue) {
        Time.timeScale = 0;
        isActive = true;
        dialoguePanel.SetActive(true);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void EndDialogue() {
        Time.timeScale = 1;
        isActive = false;
        dialoguePanel.SetActive(false);
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
        } else {
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence (string sentence) {
        dialoguePanelText.text = "";

        isWriting = true;

        foreach (char letter in sentence.ToCharArray()) {
            if (isWritingStop) {
                isWritingStop = false;
                isWriting = false;
                dialoguePanelText.text = sentence;

                Canvas.ForceUpdateCanvases();
                panelChildComponent.enabled = false;
                panelChildComponent.enabled = true;

                break;
            } else {
                dialoguePanelText.text += letter;
                yield return new WaitForSecondsRealtime(0.035f);
            }
        }

        isWriting = false;
    }

    public bool DialoguePanelIsActive {
        get { return isActive; }
    }
}
