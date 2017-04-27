using UnityEngine;
using System.Collections;

public class MineReloadUtilityOne : MonoBehaviour
{
    public Color reloadColor;
    private GameObject utilityTankOne;
    private Renderer rend;
    private Color startColor;

    private bool canDeployMines;
    private bool stop;
    public AudioSource sound;

    void Start()
    {
        canDeployMines = false;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

    }

    void Update()
    {
        if (GameObject.Find("Utility One(Clone)").GetComponent<DeplyMines>().canDeploy)
        {
            canDeployMines = true;
        }
        else if (!GameObject.Find("Utility One(Clone)").GetComponent<DeplyMines>().canDeploy)
        {
            canDeployMines = false;
        }

        if (canDeployMines == true)
        {
            rend.material.color = startColor;
        }
        else if (canDeployMines == false)
        {
            rend.material.color = reloadColor;
        }

        if (canDeployMines == true && stop == false)
        {
            Sound();
        }

        if (canDeployMines == false && stop == true)
        {
            stop = false;
        }
    }

    void Sound()
    {

        if (stop == false)
        {
            stop = true;
            sound.Play();
        }

    }

}