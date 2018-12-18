using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    Text TextScoreJump;
    [SerializeField]
    Text TextScoreCoin;

    void Start()
    {
        JumpScoreCount();
        CoinScoreCount();
    }

    public void JumpScoreCount()
    {
        TextScoreJump.text = "Прыжки: " + SceneManager.instance._JumpScore;
    }

    public void CoinScoreCount()
    {
        TextScoreCoin.text = "Монеты: " + SceneManager.instance._CoinScore;
    }
}
