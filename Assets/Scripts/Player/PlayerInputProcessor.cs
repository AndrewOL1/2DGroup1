using UnityEngine;

namespace Player
{
    public class PlayerInputProcessor
    {
        /*
         * Handle InputReaders fucntion to Player Controller
         */
        InputReader.InputReader _input;
        public float Horizontal;
        public bool IsJumping;
        public float JumpTime;
        public bool IsInteracting;
        public bool NextDialogue=false;

        public PlayerInputProcessor(InputReader.InputReader input)
        {
            this._input = input;
            _input.MoveEvent += HandleMove;
            _input.JumpEvent += HandleJump;
            _input.JumpCanceledEvent += HandleCancelledJump;
            _input.PauseEvent += HandlePause;
            _input.InteractEvent += HandleInteract;
            _input.InteractCanceledEvent += HandleCancelledInteract;
            _input.ContinueEvent += HandleContinue;
            //_input.ContinueCanceledEvent += HandleCancelledContinue;
        }


        #region Handlers
        private void HandleContinue()
        {
            Debug.Log("Continue");
            NextDialogue=true;
        }
        /*
        private void HandleCancelledContinue()
        {
            NextDialogue=false;
        }
        */
        private void HandleInteract()
        {
            IsInteracting = true;
        }
        private void HandleCancelledInteract()
        {
            IsInteracting = false;
        }
        private void HandlePause()
        {
            throw new System.NotImplementedException();//later
        }

        private void HandleCancelledJump()
        {
            IsJumping = true;
        }

        private void HandleJump()
        {
            JumpTime= Time.time;
        }

        private void HandleMove(float obj)
        {
            Horizontal = obj;
        }
        #endregion
        #region Active Control Scheme
        public void SetGameplay()=>_input.SetGameplay();
        public void SetPaused()=> _input.SetPaused();

        public void SetDialogue()
        {
            _input.SetDialogue();
        }

        #endregion
    }
}