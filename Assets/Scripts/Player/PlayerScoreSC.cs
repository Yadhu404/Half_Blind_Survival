using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreSC : MonoBehaviour
{
    public int MaxScore = 1000;
    // private int PlayerMaxHealth = 100;
    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI Score;
    public playerMove Health;
    public PlayerWonScript won;
    // Start is called before the first frame update
    void Start()
    {
        if(Health == null)
        {
            Health = GameObject.Find("Player").GetComponent<playerMove>();
        }
        if(won == null)
        {
            won = GameObject.Find("PlayerwithDimaondDetect").GetComponent<PlayerWonScript>();
        }

        Score.text = "0";
        HighScore.text = LoadHighScore().ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(won.playerwon)
        {
            PlayerScore();
        }
    }

    void PlayerScore()
    {
        Score.text = (MaxScore * Health.PlayerHealth / 100).ToString();

        SaveHighScore();
        HighScore.text = LoadHighScore().ToString();
    }

    void SaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore",0);

        if(int.Parse(Score.text) > highScore)
        {
            PlayerPrefs.SetInt("HighScore",int.Parse(Score.text));
            PlayerPrefs.Save();
        }
    }

    int LoadHighScore()
    {
        return PlayerPrefs.GetInt("HighScore",0);
    }
}
