using UnityEngine;

namespace Entities.AI.Actions.Animations
{
    [CreateAssetMenu (menuName = "AI/Actions/Animation/Bool Change")]
    public class SwitchAnimationBoolAction : Action
    {
        [SerializeField] private string boolName; // The Name of the Animation to switch to
        [SerializeField] private bool value; // The Value to switch too
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
            Animator.SetBool(boolName, value);
        }
    }
}
