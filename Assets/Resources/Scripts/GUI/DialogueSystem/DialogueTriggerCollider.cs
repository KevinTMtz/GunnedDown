using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerCollider : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Player")) {
            SoundManager.PlaySound("Typing");
            TriggerDialogue();
            Destroy(gameObject);
        }
    }
}
