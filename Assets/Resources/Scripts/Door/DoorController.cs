using UnityEngine;

public class DoorController : MonoBehaviour {
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
        if (Vector2.Distance(transform.position, player.position) < distance && !isOpen && objectiveCompleted) {
            if (inChild) SetChildDoors(true);
            else SetDoor(true);

            isOpen = true;
        } else if ((Vector2.Distance(transform.position, player.position) > distance || !objectiveCompleted) && isOpen) {
            if (inChild) SetChildDoors(false);
            else SetDoor(false);

            isOpen = false;
        }
    }

    private void SetDoor(bool state) {
        PlayDoorSound();
        animator.SetBool("isOpen", state);
    }

    private void SetChildDoors(bool state) {
        PlayDoorSound();
        if (animatorChild1.gameObject.activeSelf)
            animatorChild1.SetBool("isOpen", state);
        if (animatorChild2.gameObject.activeSelf)
            animatorChild2.SetBool("isOpen", state);
        GetComponent<BoxCollider2D>().enabled = !state;
    }

    public bool ObjectiveCompleted {
        get { return objectiveCompleted; }
        set { objectiveCompleted = value; }
    }

    private void PlayDoorSound() {
        audioSrc.PlayOneShot(audioClip, 1f);
    }
}
