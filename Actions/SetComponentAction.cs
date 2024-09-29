using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.XR;

namespace Entities.AI.Actions
{
    [CreateAssetMenu (menuName = "AI/Actions/Set Component")]
    public class SetComponentAction : Action
    {
        public override void Initialize(Brain brain)
        {
        }

        public override void Act(Brain brain)
        {
            brain.GetComponent<NavMeshAgent>().enabled = true;
            brain.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}