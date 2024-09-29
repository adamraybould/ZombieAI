namespace Entities.AI
{
    [System.Serializable]
    public class Transition
    {
        public Condition condition;

        public State trueState; // If True, Transition to this State
        public State falseState; // If False, Transition to this State
    }
}
