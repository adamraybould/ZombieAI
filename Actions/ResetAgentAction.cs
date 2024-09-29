using UnityEngine;

namespace Entities.AI.Actions
{
    [CreateAssetMenu (menuName = "AI/Actions/Reset Nav Agent")]
    public class ResetAgentAction : Action
    {
        public override void Initialize(Brain brain)
        {
        }

        public override void Act(Brain brain)
        {
            brain.GetNavigationAgent().enabled = false;
            brain.GetNavigationAgent().enabled = true;
        }
    }
}