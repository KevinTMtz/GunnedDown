using UnityEngine;

public class Boss_Roar : StateMachineBehaviour {
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.GetComponent<BossHealth>().ActivateInvulnerability();
        animator.GetComponent<BossShoot>().StopFiring();
        SoundManager.PlaySound("DragonRoar");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.GetComponent<BossHealth>().DeactivateInvulnerability();
    }
}
