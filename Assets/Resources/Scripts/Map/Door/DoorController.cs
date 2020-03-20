using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator animator;
    private Transform player;

    private bool isOpen;

    //We should have an array of Objectives (for now they would be to defeat all enemies in a room)
    //private bool objectivesCompleted = true;
    
    private void Start() {
        isOpen = false;
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    
    private void Update() {
        if (Vector2.Distance(transform.position, player.position) < 4 && !isOpen) {
            Open();
            isOpen = true;
        } else if (Vector2.Distance(transform.position, player.position) > 4 && isOpen) {
            Close();
            isOpen = false;
        }
    }
    
    private void Open() {
        //Debug.Log("Opening");
        SoundManager.PlaySound("MetalSlide");
        animator.SetBool("isOpen", true);
    }
    
    private void Close() {
        //Debug.Log("Closing");
        SoundManager.PlaySound("MetalSlide");
        animator.SetBool("isOpen", false);
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Enter");
        if(objectivesCompleted) Open();
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (objectivesCompleted) Close();
    }
    */
}
