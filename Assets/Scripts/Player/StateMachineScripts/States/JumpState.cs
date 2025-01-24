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
        }

        public override void FixedUpdate()
        {
            player.PlayerLocomotion.GroundedVelocityMovement(player.InputProcessor.Horizontal);
        }
    }
}