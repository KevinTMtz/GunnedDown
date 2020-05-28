using UnityEngine;

public class OutlineChanger : MonoBehaviour {
    private SpriteRenderer spriteR;
    public float distance;
    private bool isActive;

    public Material m1;
    public Material m2;

    private Transform player;
    
    void Start() {
        player = GameObject.Find("Player").transform;
        spriteR = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (Vector2.Distance(transform.position, player.position) < distance && !isActive) {
            spriteR.material = m2;
            isActive = !isActive;
        } else if (Vector2.Distance(transform.position, player.position) > distance && isActive) {
            isActive = !isActive;
            spriteR.material = m1;
        }
    }
}
