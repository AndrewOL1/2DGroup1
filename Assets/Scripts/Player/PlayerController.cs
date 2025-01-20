using System;
using Dreamteck.Splines;
using Player.StateMachineScripts;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    /*
     * This Player controller is using a state machine to handle conditions. The States are held and made in the StateCollection.
     * The input is handled in PlayerInputProcessor and InputReader(This removes unneeded data from the default new InputSystem)
     * The PlayerConfinuration/playerData hold all player values
     * The PlayerCollision handle the collision of the player
     *
     * Init
     * State machine and the state collection
     * MUST DEFINE STATE TRANSITIONS IN AWAKE
     * At(from,to,condition)
     * Any(to,condition)
     */
    public class PlayerController : MonoBehaviour
    {
       # region Variables
       StateCollection _states;
       public PlayerInputProcessor InputProcessor;
       StateMachine _stateMachine;
       public PlayerLocomotion PlayerLocomotion;

       [SerializeField] private Rigidbody rb;
       [SerializeField] private InputReader inputReader;
       [SerializeField] private PlayerConfiguration playerData;
       [SerializeField] private Animator animator;
       [SerializeField] private PlayerCollision playerCollision;
       
       [Header("Splines")]
       [SerializeField] private  SplineComputer groundSpline;
       [SerializeField] private  SplineComputer airSpline;
       [SerializeField] private  SplineTracer splineTracer;
       
       
       #endregion

       private void Awake()
       {
           _stateMachine = new StateMachine();
           _states = new StateCollection(this,animator,playerData);
           InputProcessor = new PlayerInputProcessor(inputReader);
           PlayerLocomotion = new PlayerLocomotion(rb, playerData,groundSpline);
           playerCollision.setPlayerLocomotion(PlayerLocomotion);
           //define transitions
           At(_states.jumpState,_states.locomotionState, new FuncPredicate(()=> playerCollision.Ground));
           At(_states.locomotionState,_states.jumpState, new FuncPredicate(()=> InputProcessor.IsJumping&&playerCollision.Ground));
           At(_states.locomotionState,_states.idleState, new FuncPredicate(()=> rb.velocity.z < 0.5f&&InputProcessor.Horizontal==0));
           At(_states.idleState,_states.locomotionState, new FuncPredicate(()=> InputProcessor.Horizontal!=0));
           At(_states.idleState,_states.jumpState, new FuncPredicate(()=> InputProcessor.IsJumping&&playerCollision.Ground));
           At(_states.jumpState,_states.idleState, new FuncPredicate(()=> InputProcessor.Horizontal==0&&playerCollision.Ground));
           //inital state
           _stateMachine.SetState(_states.idleState);
       }
       void At(IState from, IState to, IPredicate condition) => _stateMachine.AddTransition(from, to, condition);
       void Any(IState to, IPredicate condition) => _stateMachine.AddAnyTransition(to, condition);

       private void Update()
       {
           _stateMachine.Update();
       }
       private void FixedUpdate()
       {
           _stateMachine.FixedUpdate();
       }
    }
}
