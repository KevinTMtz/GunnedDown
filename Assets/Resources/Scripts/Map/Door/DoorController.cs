using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator animator;
    //We should have an array of Objectives (for now they would be to defeat all enemies in a room)
    private bool objectivesCompleted=true;
    private void Open()
    {
        Debug.Log("Opening");
        animator.SetBool("isOpen", true);
    }
    private void Close()
    {
        Debug.Log("Closing");
        animator.SetBool("isOpen", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if(objectivesCompleted) Open();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (objectivesCompleted) Close();
    }

}
