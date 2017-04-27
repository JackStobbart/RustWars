using UnityEngine;
using System.Collections;

public class BasicTankTurret : MonoBehaviour {

    private Camera mainCamera;

    public float rotateSpeed;

    public bool upgradeMenu;

    public bool placingItem;

	// Use this for initialization
	void Start () {
        mainCamera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

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

        if(placingItem == false)
            {
            if (upgradeMenu == false)
            {
                Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
                Plane groundPlane = new Plane(Vector3.up, Vector3.zero); // zero = startpoint, change to raise the aim point
                float rayLength;

                if (groundPlane.Raycast(cameraRay, out rayLength))
                {
                    Vector3 pointToLook = (cameraRay.GetPoint(rayLength) - transform.position);
                    Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);
                    Quaternion rot = Quaternion.LookRotation(pointToLook);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotateSpeed * Time.deltaTime);
                }
            }
        }
	}
}
