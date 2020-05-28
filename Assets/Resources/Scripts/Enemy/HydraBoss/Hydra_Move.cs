using UnityEngine;

public class Hydra_Move : StateMachineBehaviour {
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        int random;
        while (true) {
            random = Random.Range(0, animator.gameObject.GetComponent<Hydra>().targets.Length);
            if (random != animator.gameObject.GetComponent<Hydra>().lastTarget)
                break;
        }
        animator.gameObject.GetComponent<Hydra>().lastTarget = random;
        animator.gameObject.transform.position = animator.gameObject.GetComponent<Hydra>().targets[random].position;        
    }
}
