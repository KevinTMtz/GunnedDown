using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_Dead : StateMachineBehaviour
{
    private GameObject minotaur;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        minotaur = animator.transform.parent.gameObject;
    }
    
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       Destroy(minotaur);
    }
}
