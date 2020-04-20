using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator animator;
    private Transform player;

    private bool isOpen;
    
    private bool objectiveCompleted = true;

    public int distance;

    public bool inChild;
    public Animator animatorChild1;
    public Animator animatorChild2;
    
    private void Start() {
        isOpen = false;
        
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    
    private void Update() {
        closeOrOpen();
    }

    private void closeOrOpen() {
        if (Vector2.Distance(transform.position, player.position) < distance && !isOpen && objectiveCompleted) {
            if (inChild)
                OpenChilds();
            else
                Open();
            
            isOpen = true;
        } else if (Vector2.Distance(transform.position, player.position) > distance && isOpen || (!objectiveCompleted) && isOpen) {
            if (inChild)
                CloseChilds();
            else
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

    private void OpenChilds() {
        SoundManager.PlaySound("MetalSlide");
        animatorChild1.SetBool("isOpen", true);
        animatorChild2.SetBool("isOpen", true);
        GetComponent<BoxCollider2D>().enabled = false;
    }
    
    private void CloseChilds() {
        SoundManager.PlaySound("MetalSlide");
        animatorChild1.SetBool("isOpen", false);
        animatorChild2.SetBool("isOpen", false);
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public bool ObjectiveCompleted {
        get { return objectiveCompleted; }
        set { objectiveCompleted = value; }
    }
}
