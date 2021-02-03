using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Result : MonoBehaviour
{
    public float Timer;
    public List<ResultList> result;

    [System.Serializable]
    public class ResultList
    {
        public GameObject Driver;
        public float Time;
        public float Minutes;
        public float Seconds;
    }

    void Update()
    {
        Timer += Time.deltaTime;
    }

    public void newSorting()
    {
        result = result.OrderBy(w => w.Time).ToList();
    }
}
