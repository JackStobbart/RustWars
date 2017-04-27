using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float currentPlayerHealth;
    public float startingPlayerHealth;

    public GameObject player;
    public Image healthBar;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        GameObject thePlayer = GameObject.FindGameObjectWithTag("PlayerCollision");
        BasicTankHealth playerScript = thePlayer.GetComponent<BasicTankHealth>();
        currentPlayerHealth = playerScript.currentHealth;
        startingPlayerHealth = playerScript.startingHealth;

        healthBar.fillAmount = currentPlayerHealth / startingPlayerHealth;

    }
}
