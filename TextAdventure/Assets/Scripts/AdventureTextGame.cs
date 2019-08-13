using TMPro;
using UnityEngine;

namespace TextAdventureGame.Scripts
{
    public class AdventureTextGame : MonoBehaviour
    {
        private State _state;
        [SerializeField] private State startingState;
        [SerializeField] private TextMeshProUGUI textComponent;
        [SerializeField] private TextMeshProUGUI TitleText;

        private void Start()
        {
            _state = startingState;
            textComponent.text = _state.GetStateStory();
        }

        private void Update()
        {
            ManageState();
        }

        private void ManageState()
        {
            var nextStates = _state.GetNextStates();

            for (var i = 0; i < nextStates.Length; i++)
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                    _state = nextStates[i];
            textComponent.text = _state.GetStateStory();
            TitleText.text = _state.name;
        }
    }
}