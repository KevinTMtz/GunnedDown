using UnityEngine;

public class Minotaur_Dead : StateMachineBehaviour {
    private GameObject minotaur;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        minotaur = animator.transform.parent.gameObject;
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       Destroy(minotaur);
    }
}
