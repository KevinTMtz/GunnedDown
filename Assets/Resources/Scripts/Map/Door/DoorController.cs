using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator animator;
    private Transform player;

    private bool isOpen;
    
    private bool objectiveCompleted = true;
    
    private void Start() {
        isOpen = false;
        
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    
    private void Update() {
        closeOrOpen();
    }

    private void closeOrOpen() {
        if (Vector2.Distance(transform.position, player.position) < 4 && !isOpen && objectiveCompleted) {
            Open();
            isOpen = true;
        } else if (Vector2.Distance(transform.position, player.position) > 4 && isOpen || (!objectiveCompleted) && isOpen) {
            Close();
            isOpen = false;
        }
    }
    
    private void Open() {
        SoundManager.PlaySound("MetalSlide");
        animator.SetBool("isOpen", true);
    }
    
    private void Close() {
        SoundManager.PlaySound("MetalSlide");
        animator.SetBool("isOpen", false);
    }

    public bool ObjectiveCompleted {
        get { return objectiveCompleted; }
        set { objectiveCompleted = value; }
    }
}
