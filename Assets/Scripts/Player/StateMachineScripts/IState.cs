
namespace Player.StateMachineScripts
{
    /*
     * Interface for states
     */
    public interface IState 
    {
        void OnEnter();
        void Update();
        void FixedUpdate();
        void OnExit();
    }
}
