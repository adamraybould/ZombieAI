using UnityEngine;

namespace Entities.AI.Conditions
{
    [CreateAssetMenu (menuName = "AI/Conditions/Delay")]
    public class Delay : Condition
    {
        [SerializeField] private float delay; // How much to delay by
        [SerializeField] private float timer = 0;
        
        public override void Initialize(Brain brain)
        {
            timer = 0;
        }

        public override bool Decide(Brain brain)
        {
            timer += 1f * Time.deltaTime;
            if (timer >= delay)
                return true;
            else
                return false;
        }
    }
}