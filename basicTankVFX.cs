using UnityEngine;
using System.Collections;

public class basicTankVFX : MonoBehaviour {

    public AudioSource fire;
    public ParticleSystem firing;
    public ParticleSystem smoke;

    public void Fire()
    {
        fire.Play();
        Instantiate(firing, transform.position, transform.rotation);
        Instantiate(smoke, transform.position, transform.rotation);
    }
}
