using UnityEngine;

namespace Entities.AI.Actions.Stat_Changes
{
    [CreateAssetMenu (menuName = "AI/Actions/Entity/Stats/Change Movement Speed")]
    public class ChangeSpeedAction : Action
    {
        [SerializeField] private float moveSpeed;

        public override void Initialize(Brain brain)
        {
        }

        public override void Act(Brain brain)
        {
            ChangeMovementSpeed(brain);
        }

        private void ChangeMovementSpeed(Brain brain)
        {
            brain.GetNavigationAgent().speed = moveSpeed;
        }
    }
}
