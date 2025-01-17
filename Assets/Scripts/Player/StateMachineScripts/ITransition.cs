namespace Player.StateMachineScripts
{
    public interface ITransition 
    {
        IState To { get; }
        IPredicate Condition{ get; }
    }
}
