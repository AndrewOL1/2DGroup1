using UnityEngine;

namespace Player.StateMachineScripts.States
{
    public class LocomotionState : BaseState
    {
        public LocomotionState(PlayerController player, Animator animator) : base(player, animator)
        {
        }

        public override void OnEnter()
        {
            animator.CrossFade(LocomotionHash,crossFadeDuration);
            player.InputProcessor.IsJumping = false;
        }

        public override void FixedUpdate()
        {
            player.PlayerLocomotion.GroundedVelocityMovement(player.InputProcessor.Horizontal);
        }
    }
}