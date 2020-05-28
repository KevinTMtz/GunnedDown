using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour {
    public DoorController[] doors;
    
    // For checking the objective
    public bool hasEnemies;
    public List<GameObject> toKill = new List<GameObject>();
    private List<GameObject> temp = new List<GameObject>();
    private BoxCollider2D bC2D;

    // For controlling the camera
    public bool hasCameraControl;
    private GameObject objectCam;
    private Camera cam;
    public Vector3 camPosition;
    public float camSize;

    // For controlling music
    public bool hasMusicControl;
    public string mainTheme;
    public string fightMusic;
    
    void Start() {
        if (hasCameraControl) {
            objectCam = GameObject.Find("Main Camera");
            cam = objectCam.GetComponent<Camera>();
        }
        
        if (hasEnemies)
            foreach (GameObject item in toKill)
                item.SetActive(false);
        
        bC2D = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update() {
        foreach (GameObject item in toKill) {
            if (item == null)
                temp.Add(item);
        }

        foreach (GameObject item in temp) {
            toKill.Remove(item);
        }

        if (toKill.Count == 0) {
            for (int i = 0; i < doors.Length; i++)
                doors[i].ObjectiveCompleted = true; 
            
            if (hasCameraControl) {
                objectCam.GetComponent<CameraMovement>().enabled = true;
                cam.orthographicSize = 8;
            }

            if (hasMusicControl) {
                FindObjectOfType<SoundManager>().Play(mainTheme);
                FindObjectOfType<SoundManager>().StopPlaying(fightMusic);
            }
            
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            for (int i = 0; i < doors.Length; i++)
                doors[i].ObjectiveCompleted = false;

            if (hasEnemies)
                foreach (GameObject item in toKill)
                    item.SetActive(true);

            if (bC2D != null)
                bC2D.enabled = false;

            if (hasCameraControl) {
                objectCam.GetComponent<CameraMovement>().enabled = false;
                cam.orthographicSize = camSize;
                objectCam.transform.position = camPosition;
            }

            if (hasMusicControl) {
                FindObjectOfType<SoundManager>().StopPlaying(mainTheme);
                FindObjectOfType<SoundManager>().Play(fightMusic);
            }
        }
    }
}
