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
            player.PlayerLocomotion.ZeroVelocity();
            if (player.triggerDialogue == true)
            {
                player.triggerDialogue = false;
            }
            else
                player.PlayerLocomotion.StartDialogue();
            player.InputProcessor.SetDialogue();
            // maybe a delay for the animation
        }

        public override void Update()
        {
            if (player.InputProcessor.NextDialogue)
            {
                player.PlayerLocomotion.DialogueUpdate(player.InputProcessor.NextDialogue);
                player.InputProcessor.NextDialogue = false;
            }
        }

        public override void FixedUpdate()
        {
            player.PlayerLocomotion.Idle();
        }

        public override void OnExit()
        {
            player.InputProcessor.JumpTime = Time.time;
            player.InputProcessor.SetGameplay();
        }
    }
}