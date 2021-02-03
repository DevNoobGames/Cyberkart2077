using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkusParticles : MonoBehaviour
{
    public ParticleSystem GroundDust;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "road")
        {
            GroundDust.Play();
        }
    }
}
