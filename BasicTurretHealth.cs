using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasicTurretHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public AudioSource basicTurretDeath;
    public ParticleSystem explode;

    public float speed;
    public Transform target;

    public bool death;


    public ParticleSystem Collapsing;

    public GameObject Smoke1;
    public GameObject Smoke2;
    public GameObject Smoke3;

    public AudioSource hammer;
    public AudioSource wrench;
    public AudioSource electricWrench;
   

    void Start()
    {
        currentHealth = startingHealth;
        hammer.Play();
        wrench.Play();
        electricWrench.Play();
        GameObject.FindGameObjectWithTag("UpgradeManager").GetComponent<UpgradeManager>().PlacingObjectFalse();
    }

    public void Update()
    {
        if (death == true)
        {
            
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    public void TakeDamage (int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            death = true;
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        Instantiate(explode, transform.position, transform.rotation);
        basicTurretDeath.Play();
        Instantiate(Collapsing, Smoke1.transform.position, Smoke1.transform.rotation);
        Instantiate(Collapsing, Smoke2.transform.position, Smoke2.transform.rotation);
        Instantiate(Collapsing, Smoke3.transform.position, Smoke3.transform.rotation);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);


    }
}
