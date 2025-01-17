using UnityEngine;

namespace Player.StateMachineScripts.States
{
    public class IdleState : BaseState
    {
        public IdleState(PlayerController player, Animator animator) : base(player, animator)
        {
        }

        public override void FixedUpdate()
        {
            player.PlayerLocomotion.Idle();
        }
    }
}