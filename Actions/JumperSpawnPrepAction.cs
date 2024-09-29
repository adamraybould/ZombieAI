using UnityEngine;
using UnityEngine.AI;

namespace Entities.AI.Actions
{
    [CreateAssetMenu (menuName = "AI/Actions/Zombies/Jumper Spawn")]
    public class JumperSpawnPrepAction : Action
    {
        [SerializeField] private Target target;
        [SerializeField] private float distanceFromTarget; // The distance to spawn from the Target

        public override void Initialize(Brain brain)
        {
            target.FindTarget();
            
        }

        public override void Act(Brain brain)
        {
            Vector3 spawnPoint = GetSpawnPosition();
            brain.transform.position = spawnPoint;
        }

        /// <summary> Returns a Vector 3 that is at an offset behind the Target </summary>
        /// <returns></returns>
        private Vector3 GetSpawnPosition()
        {
            Vector3 targetForward = Camera.main.transform.forward;
            Vector3 spawnOffset = target.GetTarget().transform.position - (targetForward * distanceFromTarget);
            
            bool foundPosition = false;
            NavMeshHit hit = default;
            while (!foundPosition)
            {
                Vector3 randomPoint = spawnOffset + Random.insideUnitSphere * 3;

                foundPosition = NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas);
            }

            spawnOffset = hit.position;
            spawnOffset.y = 100; // Makes sure the jumper is high in the air

            return spawnOffset;
        }
    }
}