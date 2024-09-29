using UnityEngine;

namespace Entities.AI.Actions.Animations
{
    [CreateAssetMenu (menuName = "AI/Actions/Switch Animation")]
    public class SwitchAnimationAction : Action
    {
        [SerializeField] private string animationName; // The Name of the Animation to switch to
        private Animator Animator;

        public override void Initialize(Brain brain)
        {
            Animator = brain.GetComponent<Animator>();
        }

        public override void Act(Brain brain)
        {
            SwitchAnimation(brain);
        }

        private void SwitchAnimation(Brain brain)
        {
            Animator.Play(animationName);  
        }
    }
}
