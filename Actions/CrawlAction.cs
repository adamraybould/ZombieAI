using UnityEngine;

namespace Entities.AI.Actions
{
    [CreateAssetMenu (menuName = "AI/Actions/Crawl")]
    public class CrawlAction : Action
    {
        [SerializeField] private float crawlSpeed;

        public override void Initialize(Brain brain)
        {
        }
    
        public override void Act(Brain brain)
        {

            Crawl(brain);
        }

        private void Crawl(Brain brain)
        {
            brain.GetComponent<Animator>().Play("Crawl");
            brain.GetNavigationAgent().speed = crawlSpeed;
        }
    }
}
