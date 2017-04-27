using UnityEngine;
using System.Collections;

public class SetTimer : MonoBehaviour {

    public bool ended;
    public float enemiesLeft;

	// Use this for initialization
	void Start () {
        ended = false;
	}
	
	// Update is called once per frame
	void Update () {
        enemiesLeft = WaveManager.enemyCount;

        if (GameObject.Find("WaveManager").GetComponent<WaveManager>().waveFive && enemiesLeft == 0)
        {
            if (ended == false)
            { 
                GameObject.Find("WaveManager").GetComponent<WaveManager>().EndingSequence();
                ended = true;
            }
        }
    }
}
    