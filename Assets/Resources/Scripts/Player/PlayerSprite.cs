using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    private PlayerAim playerAim;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float aimAngle;

    // Sprites
    private Sprite[] playerSprites = new Sprite[6];

    // Start is called before the first frame update
    void Start()
    {
        // To get aimAngle of PlayerAim
        playerAim = gameObject.GetComponent("PlayerAim") as PlayerAim;
        
        // To get the spriterenderer of the player
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();

        loadPlayerSprites();
    }

    // Update is called once per frame
    void Update()
    {
        updateSpriteInRotation();
    }

    // Change sprite depending of where the player aims
    void updateSpriteInRotation() {
        aimAngle = playerAim.AngleOfAim;
        animator.ResetTrigger("up");
        animator.ResetTrigger("up-right");
        animator.ResetTrigger("up-left");
        animator.ResetTrigger("down");
        animator.ResetTrigger("down-right");
        animator.ResetTrigger("down-left");

        if (22.5f > Mathf.Abs(aimAngle)) {
            //spriteRenderer.sprite = playerSprites[0];
            animator.SetTrigger("down-right");
        } else if (157.5f < Mathf.Abs(aimAngle)) {
            //spriteRenderer.sprite = playerSprites[4];
            animator.SetTrigger("down-left");
        } else if (22.5f < aimAngle && aimAngle < 67.5f) {
            //spriteRenderer.sprite = playerSprites[1];
            animator.SetTrigger("up-right");
        }
        else if (67.5f < aimAngle && aimAngle < 112.5f) {
            //spriteRenderer.sprite = playerSprites[2];
            animator.SetTrigger("up");
        }
        else if (112.5f < aimAngle && aimAngle < 157.5f) {
            //spriteRenderer.sprite = playerSprites[3];
            animator.SetTrigger("up-left");

        } else if (-22.5f > aimAngle && aimAngle > -67.5f) {
            //spriteRenderer.sprite = playerSprites[0];
            animator.SetTrigger("down-right");
        }
        else if (-67.5f > aimAngle && aimAngle > -112.5f) {
            //spriteRenderer.sprite = playerSprites[5];
            animator.SetTrigger("down");
        }
        else if (-112.5f > aimAngle && aimAngle > -157.5f) {
            //spriteRenderer.sprite = playerSprites[4];
            animator.SetTrigger("down-left");
        }
    }

    // Load player sprites
    void loadPlayerSprites() {
        for (int i=1; i<=6; i++)
            playerSprites[i-1] = Resources.Load<Sprite>("Sprites/Player/"+i);
    }
}
