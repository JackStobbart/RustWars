using UnityEngine;
using System.Collections;

public class RocketSound : MonoBehaviour {

    public AudioSource[] fireSounds;
    public AudioSource currentFireSound;
    int fireSound;

    // Use this for initialization
    void Start () {
        fireSound = Random.Range(0, fireSounds.Length);
        currentFireSound = fireSounds[fireSound];
        currentFireSound.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
