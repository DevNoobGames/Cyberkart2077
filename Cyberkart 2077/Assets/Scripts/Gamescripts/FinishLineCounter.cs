using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class FinishLineCounter : MonoBehaviour
{
    public int LapRound;
    public Text LapText;
    public GameObject ResultListObj;
    public Result resultList;

    void Start()
    {
        LapRound = 0;
        LapText.text = "1/3";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinishLine")
        {
            LapRound = GetComponent<AIRankCheck>().currentLap + 1;
            if (tag == "Player")
            {
                LapText.text = "LAP " + LapRound + "/3";
                if (LapRound == 4)
                {
                    LapText.text = "LAP 3/3";
                    ResultListObj.SetActive(true);
                    resultList.result.Where(x => x.Driver == transform.gameObject).SingleOrDefault().Time = resultList.Timer;
                    resultList.newSorting();
                }
            }
            if (tag == "Enemy")
            {
                if (LapRound == 4)
                {
                    resultList.result.Where(x => x.Driver == transform.gameObject).SingleOrDefault().Time = resultList.Timer;
                    resultList.newSorting();
                    gameObject.SetActive(false);
                }
            }

        }
    }
}
