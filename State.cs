using UnityEngine;

namespace Entities.AI
{
    [CreateAssetMenu (menuName = "AI/State")]
    public class State : ScriptableObject
    {
        public Action[] initialActions;
        public Action[] actions;
        public Transition[] transitions;

        // Called on Activation of the State
        public void Initialize(Brain brain)
        {
            InitializeActionsAndTransitions(brain);
        }

        public void UpdateState(Brain brain)
        {
            DoActions(brain);
            CheckTransitions(brain);
        }

        private void InitializeActionsAndTransitions(Brain brain)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                if (actions[i] != null)
                    actions[i].Initialize(brain);
            }

            for (int i = 0; i < transitions.Length; i++)
            {
                if (transitions[i] != null)
                    transitions[i].condition.Initialize(brain);
            }

            // Run Inital Actions 
            for (int i = 0; i < initialActions.Length; i++)
            {
                if (initialActions[i] != null)
                {
                    initialActions[i].Initialize(brain);
                    initialActions[i].Act(brain);
                }
            }
        }

        private void DoActions(Brain brain)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                Action action = actions[i];
                if (action != null)
                    action.Act(brain);
            }
        }

        private void CheckTransitions(Brain brain)
        {
            for (int i = 0; i < transitions.Length; i++)
            {
                if (transitions[i] == null)
                    continue;

                bool decisionSucceeded = transitions[i].condition.Decide(brain);

                if (decisionSucceeded)
                    brain.SwitchState(transitions[i].trueState);
                else 
                    brain.SwitchState(transitions[i].falseState);
            }
        }
    }
}
