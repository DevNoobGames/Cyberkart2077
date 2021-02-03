using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript1 : MonoBehaviour
{
    public GameObject target;
    
    void Update()
    {
        if (target)
        {
            float step = 25 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

            if (Vector3.Distance(transform.position, target.transform.position) < 0.5f)
            {
                target.GetComponent<RVP.VehicleDebug>().ResetRotStarter();
                Destroy(gameObject);
            }
        }
    }
}
