using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

    public Text finalScore;
    public int scoreConversion;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
        scoreConversion = ScoreManager.score;
        finalScore.text = ("Final Score " + scoreConversion.ToString());
    }
}
