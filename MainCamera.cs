using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    public GameObject player;
    public GameObject cameraHolder;

    public Camera standardCamera;
    public Camera overheadCamera;

    public GameObject wallHolder;

    public GameObject upgradePoint1;
    public GameObject upgradePoint2;
    public GameObject upgradePoint3;
    public GameObject upgradePoint4;
    public GameObject upgradePoint5;
    public GameObject upgradePoint6;
    public GameObject upgradePoint7;
    public GameObject upgradePoint8;
    public GameObject upgradePoint9;
    public GameObject upgradePoint10;
    public GameObject upgradePoint11;
    public GameObject upgradePoint12;
    public GameObject upgradePoint13;
    public GameObject upgradePoint14;
    public GameObject upgradePoint15;
    public GameObject upgradePoint16;
    public GameObject upgradePoint17;
    public GameObject upgradePoint18;
    public GameObject upgradePoint19;
    public GameObject upgradePoint20;
    public GameObject upgradePoint21;
    public GameObject upgradePoint22;
    public GameObject upgradePoint23;
    public GameObject upgradePoint24;
    public GameObject upgradePoint25;
    public GameObject upgradePoint26;
    public GameObject upgradePoint27;
    public GameObject upgradePoint28;
    public GameObject upgradePoint29;
    public GameObject upgradePoint30;
    public GameObject upgradePoint31;
    public GameObject upgradePoint32;
    public GameObject upgradePoint33;
    public GameObject upgradePoint34;
    public GameObject upgradePoint35;
    public GameObject upgradePoint36;
    public GameObject upgradePoint37;
    public GameObject upgradePoint38;
    public GameObject upgradePoint39;
    public GameObject upgradePoint40;
    public GameObject upgradePoint41;

    private Vector3 offset;
    public GameObject holder;
    public bool overheadCameraCheck;

     
	public void Start ()
    {
        standardCamera.enabled = true;
        overheadCamera.enabled = false;
        player = GameObject.FindGameObjectWithTag("ThePlayer");
        offset = transform.position - player.transform.position;
        cameraHolder = GameObject.FindGameObjectWithTag("CameraHolder");
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("ThePlayer");
        transform.position = player.transform.position + offset;
    }

    	
	void LateUpdate ()
    {
        overheadCamera.transform.position = cameraHolder.transform.position;
    }

    public void StandardCamera()
    {
        standardCamera.enabled = true;
        overheadCamera.enabled = false;
        overheadCameraCheck = false;
    }

    public void OverheadCamera()
    {
        standardCamera.enabled = false;
        overheadCamera.enabled = true;
        overheadCameraCheck = true;
        Instantiate(wallHolder, upgradePoint1.transform.position, upgradePoint1.transform.rotation);
        Instantiate(wallHolder, upgradePoint2.transform.position, upgradePoint2.transform.rotation);
        Instantiate(wallHolder, upgradePoint3.transform.position, upgradePoint3.transform.rotation);
        Instantiate(wallHolder, upgradePoint4.transform.position, upgradePoint4.transform.rotation);
        Instantiate(wallHolder, upgradePoint5.transform.position, upgradePoint5.transform.rotation);
        Instantiate(wallHolder, upgradePoint6.transform.position, upgradePoint6.transform.rotation);
        Instantiate(wallHolder, upgradePoint7.transform.position, upgradePoint7.transform.rotation);
        Instantiate(wallHolder, upgradePoint8.transform.position, upgradePoint8.transform.rotation);
        Instantiate(wallHolder, upgradePoint9.transform.position, upgradePoint9.transform.rotation);
        Instantiate(wallHolder, upgradePoint10.transform.position, upgradePoint10.transform.rotation);
        Instantiate(wallHolder, upgradePoint11.transform.position, upgradePoint11.transform.rotation);
        Instantiate(wallHolder, upgradePoint12.transform.position, upgradePoint12.transform.rotation);
        Instantiate(wallHolder, upgradePoint13.transform.position, upgradePoint13.transform.rotation);
        Instantiate(wallHolder, upgradePoint14.transform.position, upgradePoint14.transform.rotation);
        Instantiate(wallHolder, upgradePoint15.transform.position, upgradePoint15.transform.rotation);
        Instantiate(wallHolder, upgradePoint16.transform.position, upgradePoint16.transform.rotation);
        Instantiate(wallHolder, upgradePoint17.transform.position, upgradePoint17.transform.rotation);
        Instantiate(wallHolder, upgradePoint18.transform.position, upgradePoint18.transform.rotation);
        Instantiate(wallHolder, upgradePoint19.transform.position, upgradePoint19.transform.rotation);
        Instantiate(wallHolder, upgradePoint20.transform.position, upgradePoint20.transform.rotation);
        Instantiate(wallHolder, upgradePoint21.transform.position, upgradePoint21.transform.rotation);
        Instantiate(wallHolder, upgradePoint22.transform.position, upgradePoint22.transform.rotation);
        Instantiate(wallHolder, upgradePoint23.transform.position, upgradePoint23.transform.rotation);
        Instantiate(wallHolder, upgradePoint24.transform.position, upgradePoint24.transform.rotation);
        Instantiate(wallHolder, upgradePoint25.transform.position, upgradePoint25.transform.rotation);
        Instantiate(wallHolder, upgradePoint26.transform.position, upgradePoint26.transform.rotation);
        Instantiate(wallHolder, upgradePoint27.transform.position, upgradePoint27.transform.rotation);
        Instantiate(wallHolder, upgradePoint28.transform.position, upgradePoint28.transform.rotation);
        Instantiate(wallHolder, upgradePoint29.transform.position, upgradePoint29.transform.rotation);
        Instantiate(wallHolder, upgradePoint30.transform.position, upgradePoint30.transform.rotation);
        Instantiate(wallHolder, upgradePoint31.transform.position, upgradePoint31.transform.rotation);
        Instantiate(wallHolder, upgradePoint32.transform.position, upgradePoint32.transform.rotation);
        Instantiate(wallHolder, upgradePoint33.transform.position, upgradePoint33.transform.rotation);
        Instantiate(wallHolder, upgradePoint34.transform.position, upgradePoint34.transform.rotation);
        Instantiate(wallHolder, upgradePoint35.transform.position, upgradePoint35.transform.rotation);
        Instantiate(wallHolder, upgradePoint36.transform.position, upgradePoint36.transform.rotation);
        Instantiate(wallHolder, upgradePoint37.transform.position, upgradePoint37.transform.rotation);
        Instantiate(wallHolder, upgradePoint38.transform.position, upgradePoint38.transform.rotation);
        Instantiate(wallHolder, upgradePoint39.transform.position, upgradePoint39.transform.rotation);
        Instantiate(wallHolder, upgradePoint40.transform.position, upgradePoint40.transform.rotation);
        Instantiate(wallHolder, upgradePoint41.transform.position, upgradePoint41.transform.rotation);        
    }
}