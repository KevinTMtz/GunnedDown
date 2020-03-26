using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Move : StateMachineBehaviour
{
    private float waitTime;
    private Rigidbody2D rigidbody;
    private Transform player;
    private float speed;
    //private float time;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("Moving");
        waitTime = 10f;
        animator.GetComponent<BossShoot>().StopFiring();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = animator.GetComponent<Rigidbody2D>();
        speed = 3f;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Vector2 target = new Vector2(player.position.x, animator.transform.position.y);
         animator.transform.position= Vector2.MoveTowards(rigidbody.position, target, speed * Time.deltaTime);
        //Debug.Log(newPos.x + ", " + newPos.y);
        if (waitTime <= 0) animator.SetTrigger("Attack");
        else
        {
            waitTime = -Time.deltaTime;
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Once tha Move animation is finished the triggers are reset
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Roar");
    }
}
