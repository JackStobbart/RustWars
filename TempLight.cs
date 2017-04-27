using UnityEngine;
using System.Collections;

public class TempLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine (Delay());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy (gameObject);
    }

    
}
