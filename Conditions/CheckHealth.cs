using UnityEngine;

// Checks if the Health of a Entity is at or below a specific Threshold
namespace Entities.AI.Conditions
{
    [CreateAssetMenu (menuName = "AI/Conditions/Check Health")]
    public class CheckHealth : Condition
    {
        [SerializeField] private Target target;
        [SerializeField] private int threshold; 

        private EntityHealth Health;

        public override void Initialize(Brain brain)
        {
            target.FindTarget();
            Health = target.GetTarget().GetComponent<EntityHealth>();
        }

        public override bool Decide(Brain brain)
        {
            return CheckHealthThreshold(brain);
        }

        public bool CheckHealthThreshold(Brain brain)
        {
            if (Health.GetHealth() <= threshold)
                return true;
            else
                return false;
        }
    }
}
