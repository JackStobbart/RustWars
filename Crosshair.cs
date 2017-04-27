using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour
{

    public Texture2D crosshair;
    public Texture2D reloadCrosshair;
    public Texture2D menuCursor;
    public bool standardCrosshair;
    public CursorMode curMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Vector2 hotSpotMenu = Vector2.zero;
    public bool inMenu;

    // Use this for initialization
    void Start()
    {
        Cursor.SetCursor(crosshair, hotSpot, curMode);
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>().placingObject)
            {
                inMenu = true;
                Cursor.SetCursor(menuCursor, hotSpotMenu, curMode);
            }
            else if (GameObject.Find("WaveManager").GetComponent<WaveManager>().upgradeHolder)
            {
                inMenu = true;
                Cursor.SetCursor(menuCursor, hotSpotMenu, curMode);
            }
            else if (!GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>().placingObject)
            {
                inMenu = false;
            }
            else if (!GameObject.Find("WaveManager").GetComponent<WaveManager>().upgradeHolder)
            {
                inMenu = false;
            }

            if (GameObject.Find("FiringPoint").GetComponent<BasicTankShooting>().canShoot)
            {
                standardCrosshair = true;
            }
            else if (!GameObject.Find("FiringPoint").GetComponent<BasicTankShooting>().canShoot)
            {
                standardCrosshair = false;
            }


            if (standardCrosshair == true && inMenu == false)
            {
                Cursor.SetCursor(crosshair, hotSpot, curMode);
            }
            else if (standardCrosshair == false && inMenu == false)
            {
                Cursor.SetCursor(reloadCrosshair, hotSpot, curMode);
            }
        }
    }


    public void StandardCrosshair()
    {
        Cursor.SetCursor(crosshair, hotSpot, curMode);
    }

    public void ReloadCrosshair()
    {
        Cursor.SetCursor(reloadCrosshair, hotSpot, curMode);
    }
}
