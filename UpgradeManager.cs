using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

    public Transform spawnPosition;
    public GameObject upgradePoint;

    public Button Damage1;
    public Button Damage2;
    public Button Speed1;
    public Button Speed2;
    public Button Utility1;
    public Button Utility2;
    public Button Heavy1;
    public Button Heavy2;
    public Button Basic1;

    public Button Damage1Purchase;
    public Button Damage2Purchase;
    public Button Speed1Purchase;
    public Button Speed2Purchase;
    public Button Utility1Purchase;
    public Button Utility2Purchase;
    public Button Heavy1Purchase;
    public Button Heavy2Purchase;
    public Button Basic1Purchase;
    public Button RocketPurchase;
    public Button BasicTurretPurchase;
    public Button ReinforcedPurchase;
    public Button ScrapWallPurchase;

    public AudioSource wrench;
    public AudioSource electricWrench;
    public AudioSource hammer;

    public GameObject basicTank;
    public GameObject basicTankDesc;
    public GameObject heavyOne;
    public GameObject heavyOneDesc;
    public GameObject heavyTwo;
    public GameObject heavyTwoDesc;
    public GameObject speedOne;
    public GameObject speedOneDesc;
    public GameObject speedTwo;
    public GameObject speedTwoDesc;
    public GameObject damageOne;
    public GameObject damageOneDesc;
    public GameObject damageTwo;
    public GameObject damageTwoDesc;
    public GameObject utilityOne;
    public GameObject utilityOneDesc;
    public GameObject utilityTwo;
    public GameObject utilityTwoDesc;

    public GameObject heavyPreArrow;
    public GameObject damagePreArrow;
    public GameObject speedPreArrow;
    public GameObject utilityPreArrow;
    public GameObject basicPreArrow;

    public GameObject basicTurretDesc;
    public GameObject missileTurretDesc;
    public GameObject scrapWallDesc;
    public GameObject reinforcedWallDesc;

    private GameObject tankSelected;

    public GameObject simpleBarricade;
    public GameObject reinforcedBarricade;
    public GameObject simpleTurret;
    public bool placingObject;

    public bool heavyPre;
    public bool speedPre;
    public bool damagePre;
    public bool utilityPre;


    void Start()
    {
        heavyPre = false;
        speedPre = false;
        damagePre = false;
        utilityPre = false;
        basicTankDesc.SetActive(false);
        speedOneDesc.SetActive(false);
        speedTwoDesc.SetActive(false);
        damageOneDesc.SetActive(false);
        damageTwoDesc.SetActive(false);
        heavyOneDesc.SetActive(false);
        heavyTwoDesc.SetActive(false);
        utilityOneDesc.SetActive(false);
        utilityTwoDesc.SetActive(false);
        basicTurretDesc.SetActive(false);
        missileTurretDesc.SetActive(false);
        scrapWallDesc.SetActive(false);
        reinforcedWallDesc.SetActive(false);
    }

    void Update()
    {
        if (ScoreManager.currency < 100)
        {
            ScrapWallPurchase.interactable = false;
            BasicTurretPurchase.interactable = false;
            ReinforcedPurchase.interactable = false;
            RocketPurchase.interactable = false;
            Heavy1Purchase.interactable = false;
            Damage1Purchase.interactable = false;
            Speed1Purchase.interactable = false;
            Utility1Purchase.interactable = false;
            Heavy2Purchase.interactable = false;
            Damage2Purchase.interactable = false;
            Speed2Purchase.interactable = false;
            Utility2Purchase.interactable = false;
        }
        else if (ScoreManager.currency < 150)
        {
            ScrapWallPurchase.interactable = true;
            BasicTurretPurchase.interactable = false;
            ReinforcedPurchase.interactable = false;
            RocketPurchase.interactable = false;
            Heavy1Purchase.interactable = false;
            Damage1Purchase.interactable = false;
            Speed1Purchase.interactable = false;
            Utility1Purchase.interactable = false;
            Heavy2Purchase.interactable = false;
            Damage2Purchase.interactable = false;
            Speed2Purchase.interactable = false;
            Utility2Purchase.interactable = false;
        }
        else if (ScoreManager.currency < 250)
        {
            ScrapWallPurchase.interactable = true;
            BasicTurretPurchase.interactable = true;
            ReinforcedPurchase.interactable = false;
            RocketPurchase.interactable = false;
            Heavy1Purchase.interactable = false;
            Damage1Purchase.interactable = false;
            Speed1Purchase.interactable = false;
            Utility1Purchase.interactable = false;
            Heavy2Purchase.interactable = false;
            Damage2Purchase.interactable = false;
            Speed2Purchase.interactable = false;
            Utility2Purchase.interactable = false;
        }
        else if (ScoreManager.currency < 350)
        {
            ScrapWallPurchase.interactable = true;
            BasicTurretPurchase.interactable = true;
            ReinforcedPurchase.interactable = true;
            RocketPurchase.interactable = false;
            Heavy1Purchase.interactable = false;
            Damage1Purchase.interactable = false;
            Speed1Purchase.interactable = false;
            Utility1Purchase.interactable = false;
            Heavy2Purchase.interactable = false;
            Damage2Purchase.interactable = false;
            Speed2Purchase.interactable = false;
            Utility2Purchase.interactable = false;
        }
        else if (ScoreManager.currency < 450)
        {
            ScrapWallPurchase.interactable = true;
            BasicTurretPurchase.interactable = true;
            ReinforcedPurchase.interactable = true;
            RocketPurchase.interactable = true;
            Heavy1Purchase.interactable = false;
            Damage1Purchase.interactable = false;
            Speed1Purchase.interactable = false;
            Utility1Purchase.interactable = false;
            Heavy2Purchase.interactable = false;
            Damage2Purchase.interactable = false;
            Speed2Purchase.interactable = false;
            Utility2Purchase.interactable = false;
        }
        else if (ScoreManager.currency < 700)
        {
            ScrapWallPurchase.interactable = true;
            BasicTurretPurchase.interactable = true;
            ReinforcedPurchase.interactable = true;
            RocketPurchase.interactable = true;
            Heavy1Purchase.interactable = true;
            Damage1Purchase.interactable = true;
            Speed1Purchase.interactable = true;
            Utility1Purchase.interactable = true;
            Heavy2Purchase.interactable = false;
            Damage2Purchase.interactable = false;
            Speed2Purchase.interactable = false;
            Utility2Purchase.interactable = false;
        }
        else if (ScoreManager.currency >= 700)
        {
            ScrapWallPurchase.interactable = true;
            BasicTurretPurchase.interactable = true;
            ReinforcedPurchase.interactable = true;
            RocketPurchase.interactable = true;
            Heavy1Purchase.interactable = true;
            Damage1Purchase.interactable = true;
            Speed1Purchase.interactable = true;
            Utility1Purchase.interactable = true;
            Heavy2Purchase.interactable = true;
            Damage2Purchase.interactable = true;
            Speed2Purchase.interactable = true;
            Utility2Purchase.interactable = true;
        }

        if (heavyPre == true)
        {
            heavyPreArrow.SetActive(true);
            speedPreArrow.SetActive(false);
            damagePreArrow.SetActive(false);
            utilityPreArrow.SetActive(false);
            basicPreArrow.SetActive(false);
            Damage1.interactable = false;
            Damage2.interactable = false;
            Speed1.interactable = false;
            Speed2.interactable = false;
            Utility1.interactable = false;
            Utility2.interactable = false;
            Heavy1.interactable = false;
            Heavy2.interactable = true;
            Basic1.interactable = true;
        }
        else if (speedPre == true)
        {
            heavyPreArrow.SetActive(false);
            speedPreArrow.SetActive(true);
            damagePreArrow.SetActive(false);
            utilityPreArrow.SetActive(false);
            basicPreArrow.SetActive(false);
            Damage1.interactable = false;
            Damage2.interactable = false;
            Speed1.interactable = false;
            Speed2.interactable = true;
            Utility1.interactable = false;
            Utility2.interactable = false;
            Heavy1.interactable = false;
            Heavy2.interactable = false;
            Basic1.interactable = true;
        }
        else if (damagePre == true)
        {
            heavyPreArrow.SetActive(false);
            speedPreArrow.SetActive(false);
            damagePreArrow.SetActive(true);
            utilityPreArrow.SetActive(false);
            basicPreArrow.SetActive(false);
            Damage1.interactable = false;
            Damage2.interactable = true;
            Speed1.interactable = false;
            Speed2.interactable = false;
            Utility1.interactable = false;
            Utility2.interactable = false;
            Heavy1.interactable = false;
            Heavy2.interactable = false;
            Basic1.interactable = true;
        }
        else if (utilityPre == true)
        {
            heavyPreArrow.SetActive(false);
            speedPreArrow.SetActive(false);
            damagePreArrow.SetActive(false);
            utilityPreArrow.SetActive(true);
            basicPreArrow.SetActive(false);
            Damage1.interactable = false;
            Damage2.interactable = false;
            Speed1.interactable = false;
            Speed2.interactable = false;
            Utility1.interactable = false;
            Utility2.interactable = true;
            Heavy1.interactable = false;
            Heavy2.interactable = false;
            Basic1.interactable = true;
        }
        else
        {
            heavyPreArrow.SetActive(false);
            speedPreArrow.SetActive(false);
            damagePreArrow.SetActive(false);
            utilityPreArrow.SetActive(false);
            basicPreArrow.SetActive(true);
            Damage1.interactable = true;
            Damage2.interactable = false;
            Speed1.interactable = true;
            Speed2.interactable = false;
            Utility1.interactable = true;
            Utility2.interactable = false;
            Heavy1.interactable = true;
            Heavy2.interactable = false;
            Basic1.interactable = false;
        }
    }

   
    public void HeavyOne()
    {
        if (ScoreManager.currency > 449)
        {
            ScoreManager.currency -= 450;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Instantiate(heavyOne, spawnPosition.position, spawnPosition.rotation);
            heavyPre = true;
            speedPre = false;
            damagePre = false;
            utilityPre = false;
            hammer.Play();
            wrench.Play();
            electricWrench.Play();
        }
    }

    public void HeavyTwo()
    {
        if (heavyPre == true)
        {
            if (ScoreManager.currency > 699)
            {
                ScoreManager.currency -= 700;
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                Instantiate(heavyTwo, spawnPosition.position, spawnPosition.rotation);
                hammer.Play();
                wrench.Play();
                electricWrench.Play();
            }
        }
    }

    public void DamageOne()
    {
        if (ScoreManager.currency > 449)
        {
            ScoreManager.currency -= 450;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Instantiate(damageOne, spawnPosition.position, spawnPosition.rotation);
            heavyPre = false;
            speedPre = false;
            damagePre = true;
            utilityPre = false;
            hammer.Play();
            wrench.Play();
            electricWrench.Play();
        }
    }

    public void DamageTwo()
    {
        if (damagePre == true)
        {
            if (ScoreManager.currency > 699)
            {
                ScoreManager.currency -= 700;
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                Instantiate(damageTwo, spawnPosition.position, spawnPosition.rotation);
                hammer.Play();
                wrench.Play();
                electricWrench.Play();
            }
        }
    }

    public void SpeedOne()
    {
        if (ScoreManager.currency > 449)
        {
            ScoreManager.currency -= 450;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Instantiate(speedOne, spawnPosition.position, spawnPosition.rotation);
            heavyPre = false;
            speedPre = true;
            damagePre = false;
            utilityPre = false;
            hammer.Play();
            wrench.Play();
            electricWrench.Play();
        }
    }

    public void SpeedTwo()
    {
        if (speedPre == true)
        {
            if (ScoreManager.currency > 699)
            {
                ScoreManager.currency -= 700;
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                Instantiate(speedTwo, spawnPosition.position, spawnPosition.rotation);
                hammer.Play();
                wrench.Play();
                electricWrench.Play();
            }
        }
    }

    public void UtilityOne()
    {
       
       if (ScoreManager.currency > 449)
            {
                ScoreManager.currency -= 450;
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                Instantiate(utilityOne, spawnPosition.position, spawnPosition.rotation);
            heavyPre = false;
            speedPre = false;
            damagePre = false;
            utilityPre = true;
            hammer.Play();
            wrench.Play();
            electricWrench.Play();
        }
        
    }

    public void UtilityTwo()
    {
        if (utilityPre == true)
        {
            if (ScoreManager.currency > 699)
            {
                ScoreManager.currency -= 700;
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                Instantiate(utilityTwo, spawnPosition.position, spawnPosition.rotation);
                hammer.Play();
                wrench.Play();
                electricWrench.Play();
            }
        }
    }

    public void Basic()
    {
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                Instantiate(basicTank, spawnPosition.position, spawnPosition.rotation);
                heavyPre = false;
                speedPre = false;
                damagePre = false;
                utilityPre = false;
        hammer.Play();
        wrench.Play();
        electricWrench.Play();
    }

    public void SimpleBarricade()
    {
        if (ScoreManager.currency > 99)
        {
            ScoreManager.currency -= 100;
            placingObject = true;

        }
    }

    public void ReinforcedBarricade()
    {
        if (ScoreManager.currency > 249)
        {
            ScoreManager.currency -= 250;
            placingObject = true;

        }
    }

    public void SimpleTurret()
    {
        if (ScoreManager.currency > 149)
        {
            ScoreManager.currency -= 150;
            placingObject = true;

        }
    }

    public void RocketTurret()
    {
        if (ScoreManager.currency > 349)
        {
            ScoreManager.currency -= 350;
            placingObject = true;

        }
    }

    public void PlacingObjectFalse()
    {
        placingObject = false;
    }

    public void DamageOneDesc()
    {
        basicTankDesc.SetActive(false);
        speedOneDesc.SetActive(false);
        speedTwoDesc.SetActive(false);
        damageOneDesc.SetActive(true);
        damageTwoDesc.SetActive(false);
        heavyOneDesc.SetActive(false);
        heavyTwoDesc.SetActive(false);
        utilityOneDesc.SetActive(false);
        utilityTwoDesc.SetActive(false);
        basicTurretDesc.SetActive(false);
        missileTurretDesc.SetActive(false);
        scrapWallDesc.SetActive(false);
        reinforcedWallDesc.SetActive(false);
    }

    public void DamageTwoDesc()
    {
        basicTankDesc.SetActive(false);
        speedOneDesc.SetActive(false);
        speedTwoDesc.SetActive(false);
        damageOneDesc.SetActive(false);
        damageTwoDesc.SetActive(true);
        heavyOneDesc.SetActive(false);
        heavyTwoDesc.SetActive(false);
        utilityOneDesc.SetActive(false);
        utilityTwoDesc.SetActive(false);
        basicTurretDesc.SetActive(false);
        missileTurretDesc.SetActive(false);
        scrapWallDesc.SetActive(false);
        reinforcedWallDesc.SetActive(false);
    }

    public void SpeedOneDesc()
    {
        basicTankDesc.SetActive(false);
        speedOneDesc.SetActive(true);
        speedTwoDesc.SetActive(false);
        damageOneDesc.SetActive(false);
        damageTwoDesc.SetActive(false);
        heavyOneDesc.SetActive(false);
        heavyTwoDesc.SetActive(false);
        utilityOneDesc.SetActive(false);
        utilityTwoDesc.SetActive(false);
        basicTurretDesc.SetActive(false);
        missileTurretDesc.SetActive(false);
        scrapWallDesc.SetActive(false);
        reinforcedWallDesc.SetActive(false);
    }

    public void SpeedTwoDesc()
    {
        basicTankDesc.SetActive(false);
        speedOneDesc.SetActive(false);
        speedTwoDesc.SetActive(true);
        damageOneDesc.SetActive(false);
        damageTwoDesc.SetActive(false);
        heavyOneDesc.SetActive(false);
        heavyTwoDesc.SetActive(false);
        utilityOneDesc.SetActive(false);
        utilityTwoDesc.SetActive(false);
        basicTurretDesc.SetActive(false);
        missileTurretDesc.SetActive(false);
        scrapWallDesc.SetActive(false);
        reinforcedWallDesc.SetActive(false);
    }

    public void HeavyOneDesc()
    {
        basicTankDesc.SetActive(false);
        speedOneDesc.SetActive(false);
        speedTwoDesc.SetActive(false);
        damageOneDesc.SetActive(false);
        damageTwoDesc.SetActive(false);
        heavyOneDesc.SetActive(true);
        heavyTwoDesc.SetActive(false);
        utilityOneDesc.SetActive(false);
        utilityTwoDesc.SetActive(false);
        basicTurretDesc.SetActive(false);
        missileTurretDesc.SetActive(false);
        scrapWallDesc.SetActive(false);
        reinforcedWallDesc.SetActive(false);
    }

    public void HeavyTwoDesc()
    {
        basicTankDesc.SetActive(false);
        speedOneDesc.SetActive(false);
        speedTwoDesc.SetActive(false);
        damageOneDesc.SetActive(false);
        damageTwoDesc.SetActive(false);
        heavyOneDesc.SetActive(false);
        heavyTwoDesc.SetActive(true);
        utilityOneDesc.SetActive(false);
        utilityTwoDesc.SetActive(false);
        basicTurretDesc.SetActive(false);
        missileTurretDesc.SetActive(false);
        scrapWallDesc.SetActive(false);
        reinforcedWallDesc.SetActive(false);
    }

    public void UtilityOneDesc()
    {
        basicTankDesc.SetActive(false);
        speedOneDesc.SetActive(false);
        speedTwoDesc.SetActive(false);
        damageOneDesc.SetActive(false);
        damageTwoDesc.SetActive(false);
        heavyOneDesc.SetActive(false);
        heavyTwoDesc.SetActive(false);
        utilityOneDesc.SetActive(true);
        utilityTwoDesc.SetActive(false);
        basicTurretDesc.SetActive(false);
        missileTurretDesc.SetActive(false);
        scrapWallDesc.SetActive(false);
        reinforcedWallDesc.SetActive(false);
    }

    public void UtilityTwoDesc()
    {
        basicTankDesc.SetActive(false);
        speedOneDesc.SetActive(false);
        speedTwoDesc.SetActive(false);
        damageOneDesc.SetActive(false);
        damageTwoDesc.SetActive(false);
        heavyOneDesc.SetActive(false);
        heavyTwoDesc.SetActive(false);
        utilityOneDesc.SetActive(false);
        utilityTwoDesc.SetActive(true);
        basicTurretDesc.SetActive(false);
        missileTurretDesc.SetActive(false);
        scrapWallDesc.SetActive(false);
        reinforcedWallDesc.SetActive(false);
    }

    public void BasicDesc()
    {
        basicTankDesc.SetActive(true);
        speedOneDesc.SetActive(false);
        speedTwoDesc.SetActive(false);
        damageOneDesc.SetActive(false);
        damageTwoDesc.SetActive(false);
        heavyOneDesc.SetActive(false);
        heavyTwoDesc.SetActive(false);
        utilityOneDesc.SetActive(false);
        utilityTwoDesc.SetActive(false);
        basicTurretDesc.SetActive(false);
        missileTurretDesc.SetActive(false);
        scrapWallDesc.SetActive(false);
        reinforcedWallDesc.SetActive(false);
    }

    public void BasicTurret()
    {
        basicTankDesc.SetActive(false);
        speedOneDesc.SetActive(false);
        speedTwoDesc.SetActive(false);
        damageOneDesc.SetActive(false);
        damageTwoDesc.SetActive(false);
        heavyOneDesc.SetActive(false);
        heavyTwoDesc.SetActive(false);
        utilityOneDesc.SetActive(false);
        utilityTwoDesc.SetActive(false);
        basicTurretDesc.SetActive(true);
        missileTurretDesc.SetActive(false);
        scrapWallDesc.SetActive(false);
        reinforcedWallDesc.SetActive(false);
    }

    public void MissileTurret()
    {
        basicTankDesc.SetActive(false);
        speedOneDesc.SetActive(false);
        speedTwoDesc.SetActive(false);
        damageOneDesc.SetActive(false);
        damageTwoDesc.SetActive(false);
        heavyOneDesc.SetActive(false);
        heavyTwoDesc.SetActive(false);
        utilityOneDesc.SetActive(false);
        utilityTwoDesc.SetActive(false);
        basicTurretDesc.SetActive(false);
        missileTurretDesc.SetActive(true);
        scrapWallDesc.SetActive(false);
        reinforcedWallDesc.SetActive(false);
    }

    public void ScrapWall()
    {
        basicTankDesc.SetActive(false);
        speedOneDesc.SetActive(false);
        speedTwoDesc.SetActive(false);
        damageOneDesc.SetActive(false);
        damageTwoDesc.SetActive(false);
        heavyOneDesc.SetActive(false);
        heavyTwoDesc.SetActive(false);
        utilityOneDesc.SetActive(false);
        utilityTwoDesc.SetActive(false);
        basicTurretDesc.SetActive(false);
        missileTurretDesc.SetActive(false);
        scrapWallDesc.SetActive(true);
        reinforcedWallDesc.SetActive(false);
    }

    public void ReinforcedWall()
    {
        basicTankDesc.SetActive(false);
        speedOneDesc.SetActive(false);
        speedTwoDesc.SetActive(false);
        damageOneDesc.SetActive(false);
        damageTwoDesc.SetActive(false);
        heavyOneDesc.SetActive(false);
        heavyTwoDesc.SetActive(false);
        utilityOneDesc.SetActive(false);
        utilityTwoDesc.SetActive(false);
        basicTurretDesc.SetActive(false);
        missileTurretDesc.SetActive(false);
        scrapWallDesc.SetActive(false);
        reinforcedWallDesc.SetActive(true);
    }

}
