using UnityEngine;

namespace Entities.AI.Conditions
{
    [CreateAssetMenu (menuName = "AI/Conditions/Navigation Destination Reached")]
    public class NavReached : Condition
    {
        public override void Initialize(Brain brain)
        {
        }

        public override bool Decide(Brain brain)
        {
            return HasTargetBeenReached(brain);
        }

        private bool HasTargetBeenReached(Brain brain)
        {
            if (brain.GetNavigationAgent().remainingDistance < brain.GetNavigationAgent().stoppingDistance && !brain.GetNavigationAgent().pathPending)
                return true;
            else 
                return false;
        }
    }
}
