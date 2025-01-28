using UnityEngine;

namespace Player.StateMachineScripts.States
{
    public class DialogueState : BaseState
    {
        public DialogueState(PlayerController player, Animator animator) : base(player, animator)
        {
        }

        public override void OnEnter()
        {
            if (player.triggerDialogue == true)
            {
                player.triggerDialogue = false;
                player.PlayerLocomotion.Idle();
            }
            else
                player.PlayerLocomotion.StartDialogue();
            // maybe a delay for the animation
        }

        public override void OnExit()
        {
            player.InputProcessor.JumpTime = Time.time;
        }
    }
}