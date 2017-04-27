using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasicEnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public int scoreValue = 10;
    public int currencyValue = 50;
    public int countValue = 1;

    public AudioSource engine;
    public ParticleSystem explode;
    public Light explosion;

    public GameObject destroyedBasicEnemy;

    bool isDead;

    void Awake ()
    {
        currentHealth = startingHealth;
        WaveManager.enemyCount += countValue;
    }

    public void TakeDamage (int amount)
    {
        if (isDead)
            return;
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Instantiate(explode, transform.position, transform.rotation);
        Instantiate(explosion, transform.position, transform.rotation);

        ScoreManager.currency += currencyValue;

        ScoreManager.score += (scoreValue * ScoreManager.multiplier);

        WaveManager.enemyCount -= countValue;

        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().MultiplierIncrease();

        Instantiate(destroyedBasicEnemy, transform.position, transform.rotation);

        Destroy (gameObject);
               
    }


}
