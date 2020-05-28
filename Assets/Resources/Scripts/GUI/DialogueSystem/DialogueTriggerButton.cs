using UnityEngine;

public class DialogueTriggerButton : MonoBehaviour {
    public Dialogue dialogue;
    public float distance;
    private bool isActive;

    private Transform player;
    
    void Start() {
        player = GameObject.Find("Player").transform;
    }

    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q) && Vector2.Distance(transform.position, player.position) < distance && !isActive) {
            isActive = true;
            SoundManager.PlaySound("Typing");
            TriggerDialogue();
        }

        if (Input.GetKeyDown(KeyCode.V) && isActive) {
            isActive = !isActive;
        }
    }
}
