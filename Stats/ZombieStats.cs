using UnityEngine;

namespace Entities.AI.Stats
{
    [CreateAssetMenu (menuName = "AI/Stats/Zombie Stats")]
    public class ZombieStats : ScriptableObject
    {
        [Header("Health")]
        [SerializeField] private int minHealth;
        [SerializeField] private int maxHealth;

        [Header("Movement Speed")]
        [SerializeField] private float minMoveSpeed;
        [SerializeField] private float maxMoveSpeed;

        public int GetRandomHealth() { return Random.Range(minHealth, maxHealth); }
        public float GetRandomMovementSpeed() { return Random.Range(minMoveSpeed, maxMoveSpeed); }
    }
}
