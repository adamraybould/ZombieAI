using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.AI
{
    [System.Serializable]
    public struct Target
    {
        [SerializeField] private string targetName; // The name of the Target Object
        private GameObject target;

        public void FindTarget() { target = GameObject.Find(targetName); }
        public GameObject GetTarget() { return target; }
    }

    public abstract class Action : ScriptableObject
    {
        // Initailization is called by the owning State on Activation
        public abstract void Initialize(Brain brain);

        // Runs the Action through the owning State's Update loop
        public abstract void Act (Brain brain);
    }
}