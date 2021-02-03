using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public bool Active;


    public IEnumerator SetActive()
    {
        yield return new WaitForSeconds(10);
        Active = true;
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<MeshCollider>().enabled = true;
    }
}
