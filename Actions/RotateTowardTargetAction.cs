using UnityEngine;

namespace Entities.AI.Actions
{
    [CreateAssetMenu (menuName = "AI/Actions/Rotate Toward Entity")]
    public class RotateTowardTargetAction : Action
    {
        [SerializeField] private Target target;
        
        public override void Initialize(Brain brain)
        {
            target.FindTarget();
        }

        public override void Act(Brain brain)
        {
            brain.transform.LookAt(target.GetTarget().transform.position);
        }
    }
}