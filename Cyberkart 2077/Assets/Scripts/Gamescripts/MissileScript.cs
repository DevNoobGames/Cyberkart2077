using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public Transform Player;
    public float OverlapRadius = 10.0f;

    private Transform nearestEnemy;
    private int enemyLayer;

    private void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Vehicles");

    }

    private void Update()
    {
        if (nearestEnemy != null)
        {
            //nearestEnemy.GetComponent<MeshRenderer>().material.color = Color.green;
            Debug.Log(nearestEnemy.transform.parent.name);
        }

        Collider[] hitColliders = Physics.OverlapSphere(Player.position, OverlapRadius, 1 << enemyLayer);
        float minimumDistance = Mathf.Infinity;
        foreach (Collider collider in hitColliders)
        {
            if (collider.transform.parent.tag != "Player")
            {
                float distance = Vector3.Distance(Player.position, collider.transform.position);
                if (distance < minimumDistance)
                {
                    minimumDistance = distance;
                    nearestEnemy = collider.transform;
                }
            }
        }
        if (nearestEnemy != null)
        {
            //nearestEnemy.GetComponent<MeshRenderer>().material.color = Color.red;
            Debug.Log("Nearest Enemy: " + nearestEnemy + "; Distance: " + minimumDistance);
        }
        else
        {
            Debug.Log("There is no enemy in the given radius");
        }

    }

}
