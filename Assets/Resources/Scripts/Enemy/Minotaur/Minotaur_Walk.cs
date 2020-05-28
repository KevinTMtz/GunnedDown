using UnityEngine;

public class Minotaur_Walk : StateMachineBehaviour {
    public float speed;

    private GameObject minotaur;
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 target;
    private float oldTime;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = GameObject.Find("Player").transform;
        minotaur = animator.transform.parent.gameObject;
        rb = minotaur.GetComponent<Rigidbody2D>();
        target = new Vector2(player.position.x, player.position.y);
        oldTime = Time.time;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (rb.position == target || Mathf.Abs(oldTime - Time.time) > 3) {
            animator.SetBool("Attacking", true);
        }
    }
}
