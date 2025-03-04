using Dreamteck.Splines;
using UnityEngine;

namespace Player.StateMachineScripts.States
{
    /*
     * grounded movement state
     */
    public class LocomotionState : BaseState
    {
        public LocomotionState(PlayerController player, Animator animator) : base(player, animator)
        {
        }

        public override void OnEnter()
        {
            if(player.Bird)
                animator.CrossFade(BirdLocomotionHash,crossFadeDuration);
            else
                animator.CrossFade(LocomotionHash,crossFadeDuration);
            player.InputProcessor.IsJumping = false;
        }

        public override void FixedUpdate()
        {
            player.PlayerLocomotion.GroundedVelocityMovement(player.InputProcessor.Horizontal);
        }

        public override void Update()
        {
            //player.PlayerLocomotion.GroundedVelocityMovement(player.InputProcessor.Horizontal);
        }
    }
}