using System.Collections;
using UnityEngine;

namespace Entities.AI.Actions
{
    [CreateAssetMenu (menuName = "AI/Actions/Entity/Attack Entity")]
    public class AttackEntityAction : Action
    {
        [SerializeField] private Target target;
        private bool attacking = false;

        private EntityAttacker Attacker;

        public override void Initialize(Brain brain)
        {
            Attacker = brain.GetComponent<EntityAttacker>();
            target.FindTarget();
        }

        public override void Act(Brain brain)
        {
            Attack(brain);
        }

        private void Attack(Brain brain)
        {
            brain.GetNavigationAgent().isStopped = true; // Stops Navigation
    
            if (!Attacker.IsAttacking)
            {
                Attacker.IsAttacking = true;
                brain.StartCoroutine(AttackPlayer(brain));
            }
        }

        public IEnumerator AttackPlayer(Brain brain)
        {
            brain.GetComponent<EntityAttacker>().SetTarget(target.GetTarget());

            brain.GetAnimator().SetBool("Moving", false);
            brain.GetAnimator().SetBool("Attacking", true);
        
            yield return new WaitForSeconds(2);

            Attacker.IsAttacking = false;
        }
    }
}
