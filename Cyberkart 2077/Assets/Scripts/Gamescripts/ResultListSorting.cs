using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ResultListSorting : MonoBehaviour
{
    public Text RankList;
    public Result resultList;

    void Update()
    {
        TimeInSecond();
        RankList.text =
            resultList.result[0].Driver.name.ToString() + " " + resultList.result[0].Minutes.ToString("00") + ":" + resultList.result[0].Seconds.ToString("00") + "\n" +
            resultList.result[1].Driver.name.ToString() + " " + resultList.result[1].Minutes.ToString("00") + ":" + resultList.result[1].Seconds.ToString("00") + "\n" +
            resultList.result[2].Driver.name.ToString() + " " + resultList.result[2].Minutes.ToString("00") + ":" + resultList.result[2].Seconds.ToString("00") + "\n" +
            resultList.result[3].Driver.name.ToString() + " " + resultList.result[3].Minutes.ToString("00") + ":" + resultList.result[3].Seconds.ToString("00") + "\n" +
            resultList.result[4].Driver.name.ToString() + " " + resultList.result[4].Minutes.ToString("00") + ":" + resultList.result[4].Seconds.ToString("00") + "\n" +
            resultList.result[5].Driver.name.ToString() + " " + resultList.result[5].Minutes.ToString("00") + ":" + resultList.result[5].Seconds.ToString("00") + "\n" +
            resultList.result[6].Driver.name.ToString() + " " + resultList.result[6].Minutes.ToString("00") + ":" + resultList.result[6].Seconds.ToString("00") + "\n" +
            resultList.result[7].Driver.name.ToString() + " " + resultList.result[7].Minutes.ToString("00") + ":" + resultList.result[7].Seconds.ToString("00");
    }

    void TimeInSecond()
    {
        foreach (Result.ResultList driver in resultList.result)
        {
            int minutes =  Mathf.FloorToInt(driver.Time / 60);
            int seconds = Mathf.RoundToInt(driver.Time % 60);
            driver.Minutes = minutes;
            driver.Seconds = seconds;
        }
    }
}
