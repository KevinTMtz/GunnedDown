using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    private PlayerAim playerAim;
    private SpriteRenderer spriteRenderer;
    private float aimAngle;

    // Start is called before the first frame update
    void Start()
    {
        // To get aimAngle of PlayerAim
        playerAim = gameObject.GetComponent("PlayerAim") as PlayerAim;
        
        // To get the spriterenderer of the player
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        updateSpriteInRotation();
    }

    // Change sprite depending of where the player aims
    void updateSpriteInRotation() {
        aimAngle = playerAim.AngleOfAim;
 
        if (22.5f > Mathf.Abs(aimAngle)) {
            spriteRenderer.color = Color.blue;
        } else if (157.5f < Mathf.Abs(aimAngle)) {
            spriteRenderer.color = Color.magenta;
        } else if (22.5f < aimAngle && aimAngle < 67.5f) {
            spriteRenderer.color = Color.red;
        } else if (67.5f < aimAngle && aimAngle < 112.5f) {
            spriteRenderer.color = Color.cyan;
        } else if (112.5f < aimAngle && aimAngle < 157.5f) {
            spriteRenderer.color = Color.yellow;
        } else if (-22.5f > aimAngle && aimAngle > -67.5f) {
            spriteRenderer.color = Color.white;
        } else if (-67.5f > aimAngle && aimAngle > -112.5f) {
            spriteRenderer.color = Color.black;
        } else if (-112.5f > aimAngle && aimAngle > -157.5f) {
            spriteRenderer.color = Color.gray;
        }
    }
}
