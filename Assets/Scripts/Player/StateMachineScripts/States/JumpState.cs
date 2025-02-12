using System.Collections;
using UnityEngine;

namespace Player.StateMachineScripts.States
{
    /*
     * Jump State calls jump
     */
    public class JumpState : BaseState
    {
        public JumpState(PlayerController player, Animator animator) : base(player, animator)
        {
        }

        public override void OnEnter()
        {
            animator.CrossFade(JumpHash, crossFadeDuration);
            player.PlayerLocomotion.JumpingVelocityMovement(player.InputProcessor.JumpTime);
            player.StartCoroutine(delay());
        }

        public override void FixedUpdate()
        {
            player.PlayerLocomotion.GroundedVelocityMovement(player.InputProcessor.Horizontal);
        }

        public override void OnExit()
        {
            player.InputProcessor.IsJumping = false;
            player.InputProcessor.JumpTime = 0;
        }
        IEnumerator delay()
        {
            yield return new WaitForSeconds(0.1f);
            player.delayB = true;
        }
    }
}