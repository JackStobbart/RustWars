using UnityEngine;
using System.Collections;

public class turretRaycast : MonoBehaviour {

    public bool cantSee;
    public string enemyTag = "Enemy";
    public string enemyCollision = "EnemyCollision";
    public string environmentTag = "Environment";

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 3000;
        Ray ray = new Ray(transform.position, forward);
        RaycastHit detection;

        if (Physics.Raycast(ray, out detection))
        {
            Debug.DrawLine(ray.origin, detection.point);
            if (detection.collider.tag == enemyCollision)
            {
                cantSee = false;
            }
            else if (detection.collider.tag == enemyTag)
            {
                cantSee = false;
            }
            else if (detection.collider.tag == environmentTag)
            {
                cantSee = true;
            }
            else cantSee = true;
        }
    }
}
