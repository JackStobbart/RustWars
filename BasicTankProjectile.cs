using UnityEngine;
using System.Collections;

public class BasicTankProjectile : MonoBehaviour {

    int damage = 50;

    public ParticleSystem explode;
    public Light explosion;

    public GameObject spawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyCollision")
        {
            Instantiate(explode, spawnPoint.transform.position, spawnPoint.transform.rotation);
            Instantiate(explosion, spawnPoint.transform.position, transform.rotation);
            other.gameObject.GetComponent<BasicEnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.tag == "Environment")
        {
            Instantiate(explode, spawnPoint.transform.position, spawnPoint.transform.rotation);
            Instantiate(explosion, spawnPoint.transform.position, spawnPoint.transform.rotation);
            Destroy(gameObject);
        }
        else if (other.tag == "Good")
        {
            Instantiate(explode, spawnPoint.transform.position, spawnPoint.transform.rotation);
            Instantiate(explosion, spawnPoint.transform.position, spawnPoint.transform.rotation);
            other.gameObject.GetComponent<BasicTurretHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
