using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerButton : MonoBehaviour
{
    public Dialogue dialogue;
    public float distance;
    private bool isActive;

    private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < distance && Input.GetKeyDown(KeyCode.Q) && !isActive) {
            isActive = true;
            SoundManager.PlaySound("Typing");
            TriggerDialogue();
        }

        if (Input.GetKeyDown(KeyCode.V) && isActive) {
            isActive = !isActive;
        }
    }
}
