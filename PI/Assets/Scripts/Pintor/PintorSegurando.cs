using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintorSegurando : StateMachineBehaviour
{
	Rigidbody2D rb;
	Humano pintor;
	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		pintor = animator.GetComponentInParent<Humano>();
		rb = animator.GetComponentInParent<Rigidbody2D>();
		//Debug.Log(pintor.name + " Esta segurando");
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetBool("EstaNoChao", pintor.estaNoChao);
		if (rb.bodyType == RigidbodyType2D.Dynamic)
		{
			animator.SetTrigger("Soltou");
		}
		if (rb.bodyType == RigidbodyType2D.Kinematic)
		{
			animator.SetTrigger("Pegou");
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
