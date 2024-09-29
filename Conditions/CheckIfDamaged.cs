using UnityEngine;

namespace Entities.AI.Conditions
{
    [CreateAssetMenu (menuName = "AI/Conditions/Is Damaged?")]
    public class CheckIfDamaged : Condition
    {
        private EntityHealth Health;

        public override void Initialize(Brain brain)
        {
            Health = brain.GetComponent<EntityHealth>();
        }

        public override bool Decide(Brain brain)
        {
            return IsDamaged(brain);
        }

        private bool IsDamaged(Brain brain)
        {
            if (Health.GetHealth() < Health.GetMaxHealth())
                return true;
            else
                return false;
        }
    }
}
