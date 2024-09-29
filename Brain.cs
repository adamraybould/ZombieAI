using System;
using Entities.AI.Stats;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Entities.AI
{
    public class Brain : MonoBehaviour
    {
        public State state;
        public State remainState;
        public State initalState; // The inital state to go back too on reset

        [SerializeField] private ZombieStats stats;
        [SerializeField] private float minMovementSpeed;
        [SerializeField] private float maxMovementSpeed;

        [SerializeField] private bool active = true; // Is the AI Active? 

        private EntityHealth EntityHealth;
        private EntityAttacker EntityAttacker;
        private NavMeshAgent NavAgent;
        private Animator Anim;

        private void Awake()
        {
            EntityHealth = GetComponent<EntityHealth>();
            EntityAttacker = GetComponent<EntityAttacker>();
            NavAgent = GetComponent<NavMeshAgent>();
            Anim = GetComponent<Animator>();
        }
        
        private void Start()
        {
            RandomizeStats();
            state.Initialize(this);
        }
        
        private void OnDisable()
        {
            state = initalState;
            
            state.Initialize(this);
            RandomizeStats();
            
            //FreezeAgent(false);
        }

        private void Update()
        {
            if (!active)
                return;

            state.UpdateState(this);
        }

        public void SwitchState(State nextState)
        {
            if (nextState != remainState)
            {
                state = nextState;
                state.Initialize(this);
            }
        }

        private void RandomizeStats()
        {
            // Randomize Propeties based on Stats
            EntityHealth.SetMaxHealth(stats.GetRandomHealth());

            int aggro = Random.Range(0, 2);
            Anim.SetBool("Aggro", aggro == 1);
            
            Anim.SetInteger("WalkIndex", Random.Range(0, 2));
            Anim.SetInteger("RunIndex", Random.Range(0, 2));
            Anim.SetInteger("DeathIndex", Random.Range(0, 3));
            //Animator.speed = Random.Range(minMovementSpeed, maxMovementSpeed); //stats.GetRandomMovementSpeed();
        }

        public void FreezeAgent(bool value)
        {
            if (value)
            {
                NavAgent.isStopped = true;
                NavAgent.updatePosition = false;
                NavAgent.updateRotation = false;
                NavAgent.ResetPath();
            }
            else
            {
                NavAgent.isStopped = false;
                NavAgent.updatePosition = true;
                NavAgent.updateRotation = true;
            }
        }

        public ZombieStats GetStats() { return stats; }
        public NavMeshAgent GetNavigationAgent() { return NavAgent; }
        public Animator GetAnimator() { return Anim; }
        public State GetCurrentState() { return state; }
    }
}
