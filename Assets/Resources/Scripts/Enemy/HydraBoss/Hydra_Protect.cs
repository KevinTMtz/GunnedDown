using UnityEngine;

public class Hydra_Protect : StateMachineBehaviour {
    public float delay;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        delay = Random.Range(3, 5);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (delay <= 0)
            animator.SetTrigger("open");
        else
            delay -= Time.deltaTime;
    }
}
