using UnityEngine;
using System.Collections;

public class BasicEnemyFiring : MonoBehaviour {

    public Transform target;
    public float Bullet_Forward_Force;

    public string goodTag = "Good";
    public string environmentTag = "Environment";
    public float range;
    public float fireRate = 0.5f;
    private float fireCountdown = 0f;
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public AudioSource shooting;

    public GameObject bulletPrefab;
    public Transform firingPoint;

    public ParticleSystem fire;
    public ParticleSystem smoke;

    public bool cantSee;


    void Start () {

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(goodTag);
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

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 3000;
        Ray ray = new Ray(transform.position, forward);
        RaycastHit detection;

        if (Physics.Raycast(ray, out detection))
        {
            Debug.DrawLine(ray.origin, detection.point);
            if (detection.collider.tag == goodTag)
            {
                cantSee = false;
            }
            else if (detection.collider.tag == environmentTag)
            {
                cantSee = true;
            }
            else cantSee = true;
        }

    


        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f && cantSee == false)
        {
                shootPlayer();
                fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }


    public void shootPlayer()
    {
            shooting.Play();
            Instantiate(fire, transform.position, transform.rotation);
            Instantiate(smoke, transform.position, transform.rotation);
        
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(bulletPrefab, firingPoint.transform.position, firingPoint.transform.rotation) as GameObject;

            Temporary_Bullet_Handler.transform.Rotate(Vector3.forward * 90);

            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

            Destroy(Temporary_Bullet_Handler, 2.0f);
         
    }
}

