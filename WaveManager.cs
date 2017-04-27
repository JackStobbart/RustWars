using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

    public Text waveText;
    public Text timerText;
    public Text enemyText;
    public float waveNumber;
    public float settingDelay;
    public float waveDelay;
    public static float enemyCount = 0;
    public GameObject endScreen;

    public GameObject enemyBasicTank;
    public GameObject enemyMediumTank;
    public GameObject enemyBossTank;
    public Transform SpawnOne;
    public Transform SpawnTwo;
    public Transform SpawnThree;
    public Transform SpawnFour;

    public bool atRepairStation;
    public bool waveSpawning;

    public GameObject UpgradeHolder;
    public GameObject newWaveNotifier;

    public bool waveOne; //when true, waveOne has been beaten, when False waveOne has not been beaten
    public bool waveTwo;
    public bool waveThree;
    public bool waveFour;
    public bool waveFive;

    public bool upgradeHolder;
    public bool inBattle;
    public bool placingUpgrades;
    public bool placingItem;

    public Transform[] spawnPositions;
    public Transform currentSpawnPosition;
    int index;

    void Start()
    {
        InvokeRepeating("RandomSpawnPoint", 1, 1);


        for (int i = 0; i < spawnPositions.Length; i++)
            endScreen.SetActive(false);
        enemyCount = 0;
        waveNumber = 0;
        waveText.text = "Wave: " + waveNumber.ToString();
        waveDelay = 60;
        waveOne = false; // all waves start false as none have been beaten when the game starts
        waveTwo = false;
        waveThree = false;
        waveFour = false;
        waveFive = false;
        inBattle = false;
        upgradeHolder = false;
        UpgradeHolder.SetActive(false);
        newWaveNotifier.SetActive(false);
    }

    void RandomSpawnPoint()
    {
        index = Random.Range(0, spawnPositions.Length);
        currentSpawnPosition.transform.position = spawnPositions[index].transform.position;

    }

    void Update()
    {
        if (waveDelay == 3)
        {
            newWaveNotifier.SetActive(true);
        }
        else if (waveDelay <= 0)
        {
            newWaveNotifier.SetActive(false);
        }

       if (!GameObject.Find("PauseManager").GetComponent<PauseScript>().paused && inBattle == false && atRepairStation == true && Input.GetKeyDown("u"))
        {
            if (upgradeHolder == true)
            {
                upgradeHolder = false;
            }
            else if (upgradeHolder == false)
            {
                upgradeHolder = true;
            }
        }
                
        if (upgradeHolder == true)
        {
            UpgradeHolder.SetActive(true);
        }
        else if (upgradeHolder == false)
        {
            UpgradeHolder.SetActive(false);
        }

        if (inBattle == true)
        {
            UpgradeHolder.SetActive(false);
            upgradeHolder = false;
        }

        if (placingItem == true)
        {
            UpgradeHolder.SetActive(false);
            upgradeHolder = false;
        }

        enemyText.text = "Enemies Left: " + enemyCount.ToString();
        if (enemyCount <= 0 && waveSpawning == false)
        {
            inBattle = false;
            waveDelay -= Time.deltaTime;
            timerText.text = "" + Mathf.Round(waveDelay);
            if (waveDelay < 0)
            {
                NextWave();
            }
        }
        
        if (inBattle == false)
        {
            if (Input.GetKeyDown("space"))
            {
                SkipWave();
            }
        }
    }

    public void close()
    {
        upgradeHolder = false;
    }

    void NextWave()
    {
        if (waveOne == true && waveTwo == true && waveThree == true && waveFour == true && waveFive == true)
        {
            EndGame();
            newWaveNotifier.SetActive(false);
        }
        else if (waveOne == true && waveTwo == true && waveThree == true && waveFour == true && enemyCount >= 0)
        {
            WaveFive();
            newWaveNotifier.SetActive(false);
        }
        else if (waveOne == true && waveTwo == true && waveThree == true && enemyCount >= 0)
        {
            WaveFour();
            newWaveNotifier.SetActive(false);
        }
        else if (waveOne == true && waveTwo == true && enemyCount >= 0)
        {
            WaveThree();
            newWaveNotifier.SetActive(false);
        }
        else if (waveOne == true && enemyCount >= 0)
        {
            WaveTwo();
            newWaveNotifier.SetActive(false);
        }
        else
        {
            WaveOne();
            newWaveNotifier.SetActive(false);
        }

    }


    void WaveOne()
    {
        //spawn enemy, then increase integer "enemies spawned" by one, when it is above 0, dont run waveDelay timer
        // in enemy code, when they die reduce enemy count by 1, that will start the next wave when they all die after being spawned
        waveSpawning = true;
        StartCoroutine(WaveOneEnemies());
        waveNumber = 1;
        waveText.text = "Wave: " + waveNumber.ToString();
        waveOne = true;
        ResetTimer();
        inBattle = true;
    }

    void WaveTwo()
    {
        waveSpawning = true;
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        StartCoroutine(WaveTwoEnemies());
        waveNumber = 2;
        waveText.text = "Wave: " + waveNumber.ToString();
        waveTwo = true;
        ResetTimer();
        inBattle = true;
    }

    void WaveThree()
    {
        waveSpawning = true;
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        StartCoroutine(WaveThreeEnemies());
        waveNumber = 3;
        waveText.text = "Wave: " + waveNumber.ToString();
        waveThree = true;
        ResetTimer();
        inBattle = true;
    }

    void WaveFour()
    {
        waveSpawning = true;
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        StartCoroutine(WaveFourEnemies());
        waveNumber = 4;
        waveText.text = "Wave: " + waveNumber.ToString();
        waveFour = true;
        ResetTimer();
        inBattle = true;
    }

    void WaveFive()
    {
        waveSpawning = true;
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        StartCoroutine(WaveFiveEnemies());
        waveNumber = 5;
        waveText.text = "Wave: " + waveNumber.ToString();
        waveFive = true;
        ResetTimer();
        inBattle = true;
    }



    void ResetTimer()
    {
        waveDelay = settingDelay;
        Update();
    }

    public void PlacingItem() // this is to remove the window when placing objects
    {
        placingItem = true;
    }

    public void FinishedPlacingItem() // this is to re-add the window when placing objects
    {
        placingItem = false;
    }

    public void SkipWave()
    {
        if (waveDelay > 3)
        {
            waveDelay = 3;
        }
    }

    public void EndGame()
    {
        
    }

    public void enterRepair()
    {
        atRepairStation = true;
    }

    public void exitRepair()
    {
        atRepairStation = false;
    }

    IEnumerator WaveOneEnemies()
    {
        yield return new WaitForSeconds(1);
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        waveSpawning = false;
    }

    IEnumerator WaveTwoEnemies()
    {
        yield return new WaitForSeconds(1);
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        waveSpawning = false;
    }

    IEnumerator WaveThreeEnemies()
    {
        yield return new WaitForSeconds(1);
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(enemyMediumTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(enemyMediumTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        waveSpawning = false;

    }

    IEnumerator WaveFourEnemies()
    {
        yield return new WaitForSeconds(1);
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(enemyMediumTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(enemyMediumTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(enemyMediumTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(enemyMediumTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        waveSpawning = false;
    }

    IEnumerator WaveFiveEnemies()
    {
        yield return new WaitForSeconds(1);
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(enemyBasicTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(enemyMediumTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(enemyMediumTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(enemyMediumTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(enemyMediumTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(enemyBossTank, spawnPositions[index].transform.position, spawnPositions[index].transform.rotation);
        waveSpawning = false;
    }

    public void EndingSequence()
    {
        endScreen.SetActive(true);
    }

}