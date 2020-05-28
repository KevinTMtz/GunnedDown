using UnityEngine;

public class Hydra_idle : StateMachineBehaviour {
    public float waitTime;
    public float attackDelay;
    public float protectDelay;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.ResetTrigger("attack");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (waitTime <= 0) {
            animator.SetTrigger("inGround");
            waitTime = 24;
        }
        else waitTime = waitTime - Time.deltaTime;

        if (attackDelay <= 0) {
            animator.SetTrigger("attack");
            attackDelay = 4;
        }
        else attackDelay = attackDelay - Time.deltaTime;

        if (protectDelay <= 0) {
            if(!animator.gameObject.GetComponent<HydraHealth>().scream2) animator.SetTrigger("close");
            protectDelay = 5;
        }
        else protectDelay -= Time.deltaTime;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.ResetTrigger("inGround");
    }
}
