using UnityEngine;

public class Boss_Entry : StateMachineBehaviour {
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.GetComponent<BossHealth>().ActivateInvulnerability();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.GetComponent<BossHealth>().DeactivateInvulnerability();
    }
}
