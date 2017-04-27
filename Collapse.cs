using UnityEngine;
using System.Collections;

public class Collapse : MonoBehaviour {

    public ParticleSystem Collapsing;

    public GameObject Smoke1;
    public GameObject Smoke2;
    public GameObject Smoke3;

    // Use this for initialization
    void Start () {
        Instantiate(Collapsing, Smoke1.transform.position, Smoke1.transform.rotation);
        Instantiate(Collapsing, Smoke2.transform.position, Smoke2.transform.rotation);
        Instantiate(Collapsing, Smoke3.transform.position, Smoke3.transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
