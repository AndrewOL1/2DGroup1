using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputReader
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "ScriptableObjects/InputReader")]
    public class InputReader : ScriptableObject, UserInput.IPausedActions, UserInput.IGameActions, UserInput.IDialogueActions
    {
        private UserInput _userInput;

        public void OnEnable()
        {
            if (_userInput == null)
            {
                _userInput = new UserInput();
                _userInput.Game.SetCallbacks(this);
                _userInput.Paused.SetCallbacks(this);
                _userInput.Dialogue.SetCallbacks(this);
                SetGameplay();
            }
        }

        public void SetGameplay()
        {
            _userInput.Game.Enable();
            _userInput.Paused.Disable();
            _userInput.Dialogue.Disable();
            Debug.Log("Gameplay enabled");
        }
        public void SetPaused()
        {
            _userInput.Game.Disable();
            _userInput.Paused.Enable();
            _userInput.Dialogue.Disable();
        }
        public void SetDialogue()
        {
            _userInput.Game.Disable();
            _userInput.Paused.Disable();
            _userInput.Dialogue.Enable();
            Debug.Log("Dialogue enabled");
        }

        public event Action<Vector2> PausedMoveEvent;
        public event Action<float> MoveEvent;
        public event Action JumpEvent;
        public event Action JumpCanceledEvent;
        public event Action PauseEvent;
        public event Action UnpauseEvent;
        public event Action InteractEvent;
        public event Action InteractCanceledEvent;
        public event Action ContinueEvent;
        public event Action ContinueCanceledEvent;
    

        void UserInput.IPausedActions.OnLocomation(InputAction.CallbackContext context)
        {
            PausedMoveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                JumpEvent?.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                JumpCanceledEvent?.Invoke();
            }
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PauseEvent?.Invoke();
                SetPaused();
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                InteractEvent?.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                InteractCanceledEvent?.Invoke();
            }
        }

        public void OnUnpause(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                UnpauseEvent?.Invoke();
                SetGameplay();
            }
        }

        void UserInput.IGameActions.OnLocomation(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<float>());
        }

        public void OnContinue(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ContinueEvent?.Invoke();
            }
        }
    }
}
