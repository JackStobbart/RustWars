using UnityEngine;
using System.Collections;

public class BasicTurretDetection : MonoBehaviour
{

    public bool targetSighted;

    private Transform target;
    private float timer;

    public GameObject FiringPoint;
    public GameObject BasicTankShell;
    public float Bullet_Forward_Force;

    private float readyToFire = 0f;
    private float reload = 2f; // 2 second cooldown


    void Update() { 

        if (targetSighted == true)
        {
            Vector3 pointToLook = GameObject.FindGameObjectWithTag("Enemy").transform.position;
            transform.LookAt(pointToLook);
            shootTarget();
        }
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Enemy")
        {
            targetSighted = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
            targetSighted = false;
        }
    }


    public void shootTarget()
    {
        if (Time.time > readyToFire + reload)
        {

            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(BasicTankShell, FiringPoint.transform.position, FiringPoint.transform.rotation) as GameObject;

            Temporary_Bullet_Handler.transform.Rotate(Vector3.forward * 90);

            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

            Destroy(Temporary_Bullet_Handler, 2.0f);

            readyToFire = Time.time;
        }

    }

}
