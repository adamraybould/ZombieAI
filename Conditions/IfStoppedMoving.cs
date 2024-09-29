using UnityEngine;

namespace Entities.AI.Conditions
{
    [CreateAssetMenu (menuName = "AI/Conditions/If Not Moving")]
    public class IfStoppedMoving : Condition
    {
        [SerializeField] private Target target;
        
        public override void Initialize(Brain brain)
        {
            target.FindTarget();
        }

        public override bool Decide(Brain brain)
        {
            float distance = Vector3.Distance(brain.transform.position, target.GetTarget().transform.position);
            if (distance <= 100)
            {
                return !brain.GetNavigationAgent().hasPath;
            }

            return false;
        }
    }
}