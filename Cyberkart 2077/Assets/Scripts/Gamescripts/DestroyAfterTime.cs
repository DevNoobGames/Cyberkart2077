using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float Time;
    public bool DestroyOnCollision;

    public void RunCour()
    {
        StartCoroutine(Destroy());
    }

    public IEnumerator Destroy()
    {
        yield return new WaitForSeconds(Time);
        Destroy(gameObject);
    }
}
