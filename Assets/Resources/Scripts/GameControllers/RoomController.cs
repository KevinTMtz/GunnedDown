using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public DoorController[] doors;
    public List<GameObject> toKill = new List<GameObject>();
    private List<GameObject> temp = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<doors.Length; i++)
            doors[i].ObjectiveCompleted = false;
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
}
