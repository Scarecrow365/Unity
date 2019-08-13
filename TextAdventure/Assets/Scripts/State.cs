using UnityEngine;

namespace TextAdventureGame.Scripts
{
    [CreateAssetMenu(menuName = "State")]
    public class State : ScriptableObject
    {
        [SerializeField] private State[] nextStates;
        [TextArea(14, 10)] [SerializeField] private string storyText;

        public string GetStateStory()
        {
            return storyText;
        }

        public State[] GetNextStates()
        {
            return nextStates;
        }
    }
}