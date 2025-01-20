namespace Player.StateMachineScripts
{
    /*
     * Interface for conditions to switch between states
     */
    public interface IPredicate
    {
        bool Evaluate();
    }
}