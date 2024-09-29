using UnityEngine;

namespace Entities.AI
{
    public abstract class Condition : ScriptableObject
    {
        // Initailization is called by the owning State on Activation
        public abstract void Initialize(Brain brain);
        public abstract bool Decide(Brain brain);
    }
}
