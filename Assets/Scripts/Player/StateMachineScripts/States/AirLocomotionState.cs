using UnityEngine;

namespace Player.StateMachineScripts.States
{
    public class AirLocomotionState : BaseState
    {
        public AirLocomotionState(PlayerController player, Animator animator) : base(player, animator)
        {
        }
        public override void OnEnter()
        {
            player.delayB = false;
        }

        public override void FixedUpdate()
        {
            player.PlayerLocomotion.GroundedVelocityMovement(player.InputProcessor.Horizontal);
        }
    }
}
