using UnityEngine;

public class DialogueTriggerCollider : MonoBehaviour {
    public Dialogue dialogue;

    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            SoundManager.PlaySound("Typing");
            TriggerDialogue();
            Destroy(gameObject);
        }
    }
}
