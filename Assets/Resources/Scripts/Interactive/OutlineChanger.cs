using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineChanger : MonoBehaviour
{
    private SpriteRenderer spriteR;
    public float distance;
    private bool isActive;

    public Material m1;
    public Material m2;

    private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        spriteR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < distance && !isActive) {
            spriteR.material = m2;
            isActive = !isActive;
        } else if (Vector2.Distance(transform.position, player.position) > distance && isActive) {
            isActive = !isActive;
            spriteR.material = m1;
        }
    }
}
