namespace Player.StateMachineScripts
{
    /*
     * Interface for Transitions
     */
    public interface ITransition 
    {
        IState To { get; }
        IPredicate Condition{ get; }
    }
}
