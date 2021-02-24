using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelekaPulo : StateMachineBehaviour {

	Personagem player;
	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//Debug.Log("Esta Pulando");
		player = animator.GetComponentInParent<Personagem>();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetBool("EstaNoChao", player.estaNoChao);
		animator.SetFloat("Velocidade", Mathf.Abs(player.velFinal.x));
		if(player.estaNaParedeDir || player.estaNaParedeEsq)
		{
			animator.SetTrigger("Grudou");
		}
		animator.SetBool("EstaNaParede", player.estaNaParedeDir || player.estaNaParedeEsq);
		animator.SetBool("EmDialogo", ManagerDialogo.current.emDialogo);
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
