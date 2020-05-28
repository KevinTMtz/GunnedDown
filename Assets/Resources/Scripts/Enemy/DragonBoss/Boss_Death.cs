using UnityEngine;

public class Boss_Death : StateMachineBehaviour {
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.GetComponent<BossShoot>().StopFiring();
    }
}
