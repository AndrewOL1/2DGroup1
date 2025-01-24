using System;

namespace Player.StateMachineScripts
{
    /*
     * Condition to switch between states
     */
    public class FuncPredicate : IPredicate
    {
        readonly Func<bool> func;

        public FuncPredicate(Func<bool> func)
        {
            this.func = func;
        }
        public bool Evaluate()
        {
            return func.Invoke();
        }
    }
}