﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoomController : MonoBehaviour
{
    public DoorController[] doors;
    
    public List<GameObject> toKill = new List<GameObject>();
    
    private List<GameObject> temp = new List<GameObject>();

    private BoxCollider2D bC2D;

    public bool hasEnemies;
    
    // Start is called before the first frame update
    void Start()
    {
        if (hasEnemies)
            foreach (GameObject item in toKill)
                item.SetActive(false);
        
        bC2D = gameObject.GetComponent<BoxCollider2D>();
    }

    // TODO: Optimize the update function
    // Update is called once per frame
    void Update()
    {
        foreach (GameObject item in toKill) {
            if (item == null)
                temp.Add(item);
        }

        foreach (GameObject item in temp) {
            toKill.Remove(item);
        }

        if (toKill.Count == 0) {
            for (int i=0; i<doors.Length; i++)
                doors[i].ObjectiveCompleted = true; 
            
            // Stop script runnning
            enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Player")) {
            for (int i=0; i<doors.Length; i++)
                doors[i].ObjectiveCompleted = false;

            if (hasEnemies)
                foreach (GameObject item in toKill)
                    item.SetActive(true);

            if (bC2D != null)
                bC2D.enabled = false;
        }
    }
}