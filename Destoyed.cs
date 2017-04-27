using UnityEngine;
using System.Collections;

public class Destoyed : MonoBehaviour {

    public bool sink;

    public float speed = 10;
    public Transform target;

    public AudioSource destroyed;

    // Use this for initialization
    void Start() {
        destroyed.Play();
        sink = true;
        StartCoroutine (Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        if (sink == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
                
    }

    IEnumerator Destroy()
    {

    yield return new WaitForSeconds(2);
        Destroy(gameObject);

    }
}
