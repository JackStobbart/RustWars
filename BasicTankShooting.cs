using UnityEngine;
using System.Collections;

public class BasicTankShooting : MonoBehaviour
{

    public GameObject FiringPoint;
    public GameObject BasicTankShell;
    public GameObject VFXPoint;
    public float Bullet_Forward_Force;

    public bool upgradeMenu;
    public bool placingItem;
    public bool canShoot;

    private float readyToFire = 0f;
    private float reload = 2f; // 2 second cooldown

    public AudioSource fire;
    public ParticleSystem firing;
    public ParticleSystem smoke;

    void Update()
    {
        if (GameObject.Find("WaveManager").GetComponent<WaveManager>().upgradeHolder)
        {
            upgradeMenu = true;
        }
        else if (!GameObject.Find("WaveManager").GetComponent<WaveManager>().upgradeHolder)
        {
            upgradeMenu = false;
        }

        if (GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>().placingObject)
        {
            placingItem = true;
        }
        else if (!GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>().placingObject)
        {
            placingItem = false;
        }

        if (placingItem == false )
        {
            if (upgradeMenu == false)
            {
                if (Time.time > readyToFire + reload)
                {
                    canShoot = true;

                    if (Input.GetMouseButtonDown(0))
                    {
                        fire.Play();

                        Instantiate(firing, VFXPoint.transform.position, VFXPoint.transform.rotation);
                        Instantiate(smoke, VFXPoint.transform.position, VFXPoint.transform.rotation);

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
                else if (Time.time < readyToFire + reload)
                {
                    canShoot = false;
                }
            }
        }
    }
}