using UnityEngine;
using System.Collections;

public class RepairStation : MonoBehaviour {

    public bool playerInside;
    public GameObject waveManager;
    public GameObject text;
    public bool cameraCheck;
    public bool inBattleCheck;
    


	// Use this for initialization
	void Start () {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update() {



        if(GameObject.Find("WaveManager").GetComponent<WaveManager>().inBattle == true)
        {
            inBattleCheck = true;
        }
        else if (!GameObject.Find("WaveManager").GetComponent<WaveManager>().inBattle == true)
        {
            inBattleCheck = false;
        }


            if (GameObject.Find("Camera").GetComponent<MainCamera>().overheadCameraCheck == true)
        {
            cameraCheck = true;
        }
        else if (GameObject.Find("Camera").GetComponent<MainCamera>().overheadCameraCheck == false)
        {
            cameraCheck = false;
        }

        if (playerInside == true && cameraCheck == text && inBattleCheck)
        {
            text.SetActive(false);
            waveManager.GetComponent<WaveManager>().enterRepair();
        }
        else if (playerInside == true && cameraCheck == false && inBattleCheck == false)
        {
            text.SetActive(true);
            waveManager.GetComponent<WaveManager>().enterRepair();
            GameObject.Find("Body").GetComponent<BasicTankHealth>().Repair();
        }
        else if (playerInside == false && cameraCheck == false )
        {
            text.SetActive(false);
            waveManager.GetComponent<WaveManager>().exitRepair();
        }
        else if (playerInside == false && cameraCheck == true)
        {
            text.SetActive(false);
            waveManager.GetComponent<WaveManager>().exitRepair();
        }
        else if (playerInside == true && cameraCheck == false && inBattleCheck == true)
        {
            text.SetActive(false);
            waveManager.GetComponent<WaveManager>().exitRepair();
        }
        else if (playerInside == true && cameraCheck == true && inBattleCheck == true)
        {
            text.SetActive(false);
            waveManager.GetComponent<WaveManager>().exitRepair();
        }
    }

        void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == ("PlayerCollision"))
            {
                playerInside = true;
            }

        }

        void OnTriggerExit(Collider other)
    {
            if (other.gameObject.tag == ("PlayerCollision"))
            {
                playerInside = false;
            }


        }
    }

        