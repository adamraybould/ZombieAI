using UnityEngine;

namespace Entities.AI.Actions.Animations
{
    [CreateAssetMenu (menuName = "AI/Actions/Animation/Trigger Change")]
    public class AnimationTriggerAction : Action
    {
        [SerializeField] private string triggerName; // The Name of the Animation to switch to
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
            Animator.SetTrigger(triggerName);
        }
    }
}
