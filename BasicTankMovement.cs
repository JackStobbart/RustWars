using UnityEngine;
using System.Collections;

public class BasicTankMovement : MonoBehaviour
{

    public float rotateSpeed = 90.0F;
    public float speed = 5.0F;
    
    public bool upgradeMenu;
    public bool placingObject;
    public bool touchingFloor;

    void Update()
    {
        var transAmount = speed * Time.deltaTime;
        var rotateAmount = rotateSpeed * Time.deltaTime;

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
                placingObject = true;
            }
        else if (!GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>().placingObject)
            {
                placingObject = false;
            }

            if (upgradeMenu == false)
            {
                    if (placingObject == false)
                    {

                        if (Input.GetKey("up"))
                            {
                                transform.Translate(0, 0, transAmount);
                            }
                        else if (Input.GetKey("w"))
                            {
                                transform.Translate(0, 0, transAmount);
                            }

                        if (Input.GetKey("down"))
                            {
                                transform.Translate(0, 0, -transAmount);
                            }
                        else if (Input.GetKey("s"))
                            {
                                transform.Translate(0, 0, -transAmount);
                            }

                        if (Input.GetKey("left"))
                            {
                                transform.Rotate(0, -rotateAmount, 0);                    
                            }
                        else if (Input.GetKey("a"))
                            {
                                transform.Rotate(0, -rotateAmount, 0);
                            }

                        if (Input.GetKey("right"))
                            {
                                transform.Rotate(0, rotateAmount, 0);
                            }
                        else if (Input.GetKey("d"))
                            {
                                transform.Rotate(0, rotateAmount, 0);
                            }
            }
        }
    }
}
