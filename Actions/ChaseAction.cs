using UnityEngine;

namespace Entities.AI.Actions
{
    [CreateAssetMenu (menuName = "AI/Actions/Move To Entity")]
    public class ChaseAction : Action
    {
        [SerializeField] private Target target;

        public override void Initialize(Brain brain)
        {
            target.FindTarget();
            
        }

        public override void Act(Brain brain)
        {
            Chase(brain);
        }

        private void Chase(Brain brain)
        {
            brain.GetNavigationAgent().SetDestination(target.GetTarget().transform.position);
            //brain.GetNavigationAgent().nextPosition = brain.transform.position;

            //Animator.speed = brain.GetNavigationAgent().speed + 0.5f;
        }
    }
}
