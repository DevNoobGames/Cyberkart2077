using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Positioning : MonoBehaviour
{
    public List<AIRankCheck> Racers;

    public List<Scores> ScoreList;

    [System.Serializable]
    public class Scores
    {
        public GameObject Driver;
        public int Score;
        public float DistanceToGo;
    }


    public void Update()
    {
        ScoreList = ScoreList.OrderByDescending(w => w.Score).ThenBy(w => w.DistanceToGo).ToList();



        /*Racers.Sort((r1, r2) => 
        {
            if (r1.currentLap != r2.currentIndex)
                return r1.currentLap.CompareTo(r2.currentLap);

            if (r1.currentIndex != r2.currentIndex)
                return r1.currentIndex.CompareTo(r2.currentIndex);

            return r1.DistToNextCheckpoint().CompareTo(r2.DistToNextCheckpoint());
        });*/
        // Racers are sorted, you can update positions on racers here if needed.

        /*Racers.Sort((r1, r2) =>
        {
            if (r1.currentLap > r2.currentLap)
                return r1.currentLap.CompareTo(r2.currentLap);

            if (r1.currentLap == r2.currentLap)
            {
                if (r1.currentIndex > r2.currentIndex)
                    return r1.currentIndex.CompareTo(r2.currentIndex);

                if (r1.currentIndex == r2.currentIndex)
                    return r1.DistToNextCheckpoint().CompareTo(r2.DistToNextCheckpoint());
            }
            return r1.DistToNextCheckpoint().CompareTo(r2.DistToNextCheckpoint());


            /*if (r1.currentLap != r2.currentIndex)
                return r1.currentLap.CompareTo(r2.currentLap);

            if (r1.currentLap != r2.currentLap)
                return r1.currentIndex.CompareTo(r2.currentIndex);

            return r1.DistToNextCheckpoint().CompareTo(r2.DistToNextCheckpoint());
        });*/
    }

}
