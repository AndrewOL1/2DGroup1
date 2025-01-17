using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "ScriptableObjects/InputReader")]
public class InputReader : ScriptableObject, UserInput.IPausedActions, UserInput.IGameActions
{
    private UserInput _userInput;

    public void OnEnable()
    {
        if (_userInput == null)
        {
            _userInput = new UserInput();
            _userInput.Game.SetCallbacks(this);
            _userInput.Paused.SetCallbacks(this);
            SetGameplay();
        }
    }

    public void SetGameplay()
    {
        _userInput.Game.Enable();
        _userInput.Paused.Disable();
    }
    public void SetPaused()
    {
        _userInput.Game.Disable();
        _userInput.Paused.Enable();
    }

    public event Action<Vector2> PausedMoveEvent;
    public event Action<float> MoveEvent;
    public event Action JumpEvent;
    public event Action JumpCanceledEvent;
    public event Action PauseEvent;
    public event Action UnpauseEvent;
    public event Action InteractEvent;
    

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
}
