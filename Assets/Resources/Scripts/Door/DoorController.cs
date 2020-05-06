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

    private AudioSource audioSrc;

    public AudioClip audioClip;
    
    private void Start() {
        isOpen = false;
        
        player = GameObject.Find("Player").GetComponent<Transform>();

        audioSrc = GetComponent<AudioSource>();
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
        PlayDoorSound();
        animator.SetBool("isOpen", true);
    }
    
    private void Close() {
        PlayDoorSound();
        animator.SetBool("isOpen", false);
    }

    private void OpenChilds() {
        PlayDoorSound();
        if (animatorChild1.gameObject.activeSelf)
            animatorChild1.SetBool("isOpen", true);
        if (animatorChild2.gameObject.activeSelf)
            animatorChild2.SetBool("isOpen", true);
        GetComponent<BoxCollider2D>().enabled = false;
    }
    
    private void CloseChilds() {
        PlayDoorSound();
        if (animatorChild1.gameObject.activeSelf)
            animatorChild1.SetBool("isOpen", false);
        if (animatorChild2.gameObject.activeSelf)
            animatorChild2.SetBool("isOpen", false);
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public bool ObjectiveCompleted {
        get { return objectiveCompleted; }
        set { objectiveCompleted = value; }
    }

    private void PlayDoorSound() {
        audioSrc.PlayOneShot(audioClip, 1f);
    }
}
