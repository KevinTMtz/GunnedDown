using UnityEngine;

public class Boss_Move : StateMachineBehaviour {
    private float waitTime;
    private Rigidbody2D rigidbody;
    private Transform player;
    private float speed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        waitTime = 10f;
        animator.GetComponent<BossShoot>().StopFiring();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = animator.GetComponent<Rigidbody2D>();
        speed = 3f;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Vector2 target = new Vector2(player.position.x, animator.transform.position.y);
        animator.transform.position = Vector2.MoveTowards(rigidbody.position, target, speed * Time.deltaTime);
        if (waitTime <= 0) animator.SetTrigger("Attack");
        else waitTime = -Time.deltaTime;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Roar");
    }
}
