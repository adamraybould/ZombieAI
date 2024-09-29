using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.AI.Actions
{
    [CreateAssetMenu (menuName = "AI/Actions/Animation/Change Animator Weight")]
    public class ChangeAnimatorWeightAction : Action
    {
        [Serializable]
        public struct AnimLayerWeight
        {
            public float weight;
            public int layerIndex;
        }

        [SerializeField] private List<AnimLayerWeight> weights;
        private Animator Anim;
        
        public override void Initialize(Brain brain)
        {
            Anim = brain.GetComponent<Animator>();
        }

        public override void Act(Brain brain)
        {
            foreach (AnimLayerWeight layer in weights)
            {
                Anim.SetLayerWeight(layer.layerIndex, layer.weight);
            }
        }
    }
}