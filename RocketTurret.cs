using UnityEngine;
using System.Collections;

public class RocketTurret : MonoBehaviour
{
    // This turret will find the closest enemy, take one seconds to lock on then fire a barrage of missiles in an aoe. Afterwards it will take 8 seconds to reload.

    public Transform target; // The target that this turret is aiming at.

    [Header("Attributes")]
    public float shotDelay = 8f; // How long the turret takes to reload.
    private float canFire = 0f; //If at least 8 seconds have passed since firing then shot delay will = 0, the same as canFire, therefore the turret will be able to shoot.
    public float range = 5000f; // How far the turret will pick a target.
    private float rocketMax = 10; // How many rockets to reset to after finished firing.
    public float rocketCount = 10; //How many rockets fired before a reload is needed.
    public float fireDelay = 0.25f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy"; //The tag that will be targeted, all enemies have this tag so it will shoot the first enemy.
    public string enemyCollision = "EnemyCollision";
    public string environmentTag = "Environment";

    public Transform partToRotate; //The part of the 3D model that will rotate to face the enemy.
    public float turnSpeed = 3f; //How fast the 3D model will spin to face the target.

    public GameObject bulletPrefab; //The projectile being fired.
    public Transform firingPoint; //Where the projectile will be fired from.

    public bool cantSeeEnemy;
    

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {

        if (gameObject.GetComponent<rocketRayCast>().cantSee)
        {
            cantSeeEnemy = true;
        }
        else if (!gameObject.GetComponent<rocketRayCast>().cantSee)
        {
            cantSeeEnemy = false;
        }

        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (canFire <= 0f && cantSeeEnemy == false)
        {
            if (target == null)
                return;

            StartCoroutine(LockingOn());
            canFire = shotDelay;
        }

        canFire -= Time.deltaTime;
               

    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortertDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortertDistance)
            {
                shortertDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortertDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        GameObject rocketGO = (GameObject)Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        TurretTestProjectile rocket = rocketGO.GetComponent<TurretTestProjectile>();

        if (rocket != null)
            rocket.Seek(target);
    }

    void OnDrawGizomosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }



    IEnumerator FiringRocket()
    {
        if (rocketCount >= 1)
        {
            GameObject rocketGO = (GameObject)Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            TurretTestProjectile rocket = rocketGO.GetComponent<TurretTestProjectile>();
            
            if (rocket != null)
                rocket.Seek(target);

            rocketCount = rocketCount - 1;
            yield return new WaitForSeconds(fireDelay);
            StartCoroutine(FiringRocket());
        }
        else if (rocketCount <= 0)
        {
            canFire = shotDelay;
            rocketCount = rocketMax;
            StopCoroutine(FiringRocket());
        }
        

    }

    IEnumerator LockingOn()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(FiringRocket());
    }

}
