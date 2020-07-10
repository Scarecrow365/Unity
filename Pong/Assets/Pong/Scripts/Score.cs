using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreFirstPlayer, _scoreSecondPlayer;
    [SerializeField] private GameData _gameData;

    private void Start()
    {
        _gameData.OnResetScore += ResetScore;
        _gameData.OnChangePlayer1Score += UpdateScoreFirstPlayer;
        _gameData.OnChangePlayer2Score += UpdateScoreSecondPlayer;
    }

    private void ResetScore() => _scoreFirstPlayer.text = _scoreSecondPlayer.text = "0";
    private void UpdateScoreFirstPlayer() => _scoreFirstPlayer.text = $"{_gameData.CurrentScorePlayer1}";
    private void UpdateScoreSecondPlayer() => _scoreSecondPlayer.text = $"{_gameData.CurrentScorePlayer2}";
    
}