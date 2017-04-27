using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;
    public static int currency;
    public static int multiplier;

    public static bool endGame;

    public Text scoreText;
    public Text currencyText;
    public Text scoreMultiplier;

    public Text healthText;
    public static float health;

    public GameObject EndGameHolder;

    void Start()
    {
        score = 0;
        currency = 400;
        SetScoreText();
        SetCurrencyText();
        endGame = false;
        EndGameHolder.SetActive(false);
        multiplier = 1;
     }

    void LateUpdate()
    {
        SetMutliplierText();
        SetScoreText();
        SetCurrencyText();
        SetHealthText();
        if (endGame == true)
        {
            EndGame();
        }
    }

    void SetScoreText()
        {
        scoreText.text = "Score: " + score.ToString();
        }

    void SetFinalScoreText()
    {
        scoreText.text = "Final Score: " + score.ToString();
    }

    void SetCurrencyText()
        {
        currencyText.text = "Currency: " + currency.ToString();
        }

    void SetHealthText()
        {
        healthText.text = "Health: " + health.ToString();
        }

    public void EndGame()
    {
        EndGameHolder.SetActive(true);
    }

    public void MultiplierIncrease()
    {
        multiplier = multiplier + 1;
    }

    public void MultiplierReset()
    {
        multiplier = 1;
    }

    public void SetMutliplierText()
    {
        scoreMultiplier.text = "x" + multiplier.ToString();
    }

    public void ResetHealth()
    {

    }
}