using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasicTankHealth : MonoBehaviour
{
    public float startingHealth = 100;
    public float currentHealth = 0f;
    public float shakeAmount = 1;

    public AudioSource destroyed;



    void Awake()
    {
        ScoreManager.health = 0;
        currentHealth = startingHealth;
        ScoreManager.health += currentHealth;
    }


    public void TakeDamage(int amount)
    {

        currentHealth -= amount;
        ScoreManager.health -= amount;
        CameraShake.shakeDuration += shakeAmount;
        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().MultiplierReset();
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        ScoreManager.endGame = true;
        Destroy(gameObject);
         // spawn a destroyed version of the player then end game.
    }

    public void Repair()
    {
        currentHealth = startingHealth;
        ScoreManager.health = currentHealth;
    }


}
