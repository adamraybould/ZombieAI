using UnityEngine;

namespace Entities.AI.Actions
{
    [CreateAssetMenu (menuName = "AI/Actions/Play Audio")]
    public class PlayAudioAction : Action
    {
        [SerializeField] private AudioClip audio; // Audio to play
        [SerializeField] private float volume = 1.0f;
        private AudioSource AudioSource;
        
        public override void Initialize(Brain brain)
        {
            AudioSource = brain.GetComponent<AudioSource>();
        }

        public override void Act(Brain brain)
        {
            AudioSource.PlayOneShot(audio, volume);
        }
    }
}