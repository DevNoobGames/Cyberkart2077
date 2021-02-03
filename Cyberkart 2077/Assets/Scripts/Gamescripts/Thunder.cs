using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class Thunder : MonoBehaviour
{
    public Fog fog;
    public bool Up;
    public bool Running;
    public float UpRange;
    public float DownRange;

    void Start()
    {
        Up = false;
        Volume volume = GameObject.Find("PostProcessing").GetComponent<Volume>();
        Fog tempFog;

        if (volume.profile.TryGet<Fog>(out tempFog))
        {
            fog = tempFog;
        }
        UpRange = Random.Range(10, 17);
        DownRange = Random.Range(1, 9);
    }

    private void OnEnable()
    {
        Running = true;
        StartCoroutine(thunderRun());
    }

    // Update is called once per frame
    void Update()
    {
        if (Running)
        {
            if (!Up)
            {
                fog.meanFreePath.value = fog.meanFreePath.value - 0.2f;
                if (fog.meanFreePath.value <= DownRange)
                {
                    Up = true;
                    DownRange = Random.Range(1, 9);
                }
            }
            if (Up)
            {
                fog.meanFreePath.value = fog.meanFreePath.value + 0.1f;
                if (fog.meanFreePath.value >= UpRange)
                {
                    Up = false;
                    UpRange = Random.Range(10, 17);
                }
            }
        }
    }

    IEnumerator thunderRun()
    {
        yield return new WaitForSeconds(2);
        Running = false;
        fog.meanFreePath.value = 16.95f;
        this.enabled = false;
    }
}
