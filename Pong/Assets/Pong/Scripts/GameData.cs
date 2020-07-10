using System;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private int _currentScorePlayer1;
    private int _currentScorePlayer2;

    public int CurrentScorePlayer1
    {
        get => _currentScorePlayer1;
        set
        {
            _currentScorePlayer1 = value;
            OnChangePlayer1Score?.Invoke();
        }
    }

    public int CurrentScorePlayer2
    {
        get => _currentScorePlayer2;
        set
        {
            _currentScorePlayer2 = value;
            OnChangePlayer2Score?.Invoke();
        }
    }

    public event Action OnResetScore;
    public event Action OnChangePlayer1Score;
    public event Action OnChangePlayer2Score;

    public void ResetAllScore()
    {
        OnResetScore?.Invoke();
        CurrentScorePlayer1 = 0;
        CurrentScorePlayer2 = 0;
    }
}