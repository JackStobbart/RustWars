using UnityEngine;
using System.Collections;

public class Landmine : MonoBehaviour {

    public int damage = 100;
    public ParticleSystem explode;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyCollision")
        {
            other.gameObject.GetComponent<BasicEnemyHealth>().TakeDamage(damage);
            Instantiate(explode, gameObject.transform);
            Destroy(gameObject);

        }
    }
}
