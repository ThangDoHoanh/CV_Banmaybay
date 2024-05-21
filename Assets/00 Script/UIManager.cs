using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.LowLevel.InputEventTrace;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] Text _scoreText;
    [SerializeField] int _Score = 0, _Highscore;

    void Start()
    {
        _Highscore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreText();
    }
    public void SetScore(int score)
    {
        if (score < 0 || score >= 6)
            return;
        _Score += score;
       
        if (_Score > _Highscore)
        {
            _Highscore = _Score;

            PlayerPrefs.SetInt("HighScore", _Highscore);
        }
        UpdateScoreText();
    }
    void UpdateScoreText()
    {
        _scoreText.text = "High Score : " + _Highscore + "\n"
            + "Score : " + _Score;
    }

}
