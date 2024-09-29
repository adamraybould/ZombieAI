using UnityEngine;

namespace Entities.AI.Actions
{
    [CreateAssetMenu (menuName = "AI/Actions/Entity/Death")]
    public class EntityDeathAction : Action
    {
        private EntityHealth Health;

        public override void Initialize(Brain brain)
        {
            Health = brain.GetComponent<EntityHealth>();
        }

        public override void Act(Brain brain)
        {
            Death(brain);
        }

        private void Death(Brain brain)
        {
            // Halts Navigation
            brain.GetNavigationAgent().isStopped = true;
            brain.GetNavigationAgent().ResetPath();
            //brain.GetNavigationAgent().speed = 0;

            brain.GetAnimator().speed = 1.0f;
            
            Health.DamageEntity(Health.GetHealth());
            brain.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
