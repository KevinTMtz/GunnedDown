using UnityEngine;

public class PlayerSprite : MonoBehaviour {
    private PlayerAim playerAim;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float aimAngle;

    // Sprites
    private Sprite[] playerSprites = new Sprite[6];

    void Start() {
        // To get aimAngle of PlayerAim
        playerAim = gameObject.GetComponent<PlayerAim>();
        // To get the spriterenderer of the player
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        loadPlayerSprites();
    }

    void Update() {
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
            animator.SetTrigger("down-right");
        } else if (157.5f < Mathf.Abs(aimAngle)) {
            animator.SetTrigger("down-left");
        } else if (22.5f < aimAngle && aimAngle < 67.5f) {
            animator.SetTrigger("up-right");
        } else if (67.5f < aimAngle && aimAngle < 112.5f) {
            animator.SetTrigger("up");
        } else if (112.5f < aimAngle && aimAngle < 157.5f) {
            animator.SetTrigger("up-left");
        } else if (-22.5f > aimAngle && aimAngle > -67.5f) {
            animator.SetTrigger("down-right");
        } else if (-67.5f > aimAngle && aimAngle > -112.5f) {
            animator.SetTrigger("down");
        } else if (-112.5f > aimAngle && aimAngle > -157.5f) {
            animator.SetTrigger("down-left");
        }
    }

    // Load player sprites
    void loadPlayerSprites() {
        for (int i = 1; i <= 6; i++)
            playerSprites[i - 1] = Resources.Load<Sprite>("Sprites/Player/" + i);
    }
}
