using UnityEngine;

namespace Player
{
    public class PlayerInputProcessor
    {
        /*
         * Handle InputReaders fucntion to Player Controller
         */
        InputReader _input;
        public float Horizontal;
        public bool IsJumping;
        public float JumpTime;
        public bool IsInteracting;

        public PlayerInputProcessor(InputReader input)
        {
            this._input = input;
            _input.MoveEvent += HandleMove;
            _input.JumpEvent += HandleJump;
            _input.JumpCanceledEvent += HandleCancelledJump;
            _input.PauseEvent += HandlePause;
            _input.InteractEvent += HandleInteract;
            _input.InteractCanceledEvent += HandleCancelledInteract;
        }
        

        #region Handlers
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
    }
}