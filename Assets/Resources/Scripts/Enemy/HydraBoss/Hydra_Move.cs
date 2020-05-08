using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydra_Move : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Once tha Move animation is finished the triggers are reset
        int random;
        while (true)
        {
            random = Random.Range(0, animator.gameObject.GetComponent<Hydra>().targets.Length);
            if (random != animator.gameObject.GetComponent<Hydra>().lastTarget) break;
        }
        //Debug.Log(random);
        animator.gameObject.GetComponent<Hydra>().lastTarget = random;
        animator.gameObject.transform.position = animator.gameObject.GetComponent<Hydra>().targets[random].position;
        
    }
}
