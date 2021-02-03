using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AIRankCheck : MonoBehaviour
{
    //
    public int currentLap = 0;
    public int currentIndex = 0;
    public RankingSystem track;
    
    public float DistanceToNext;

    public Positioning Ranklist;
    //

    private void Awake()
    {
        track = FindObjectOfType<RankingSystem>();
    }

    private void Start()
    {
        //Ranklist.ScoreList.Where(x => x.Driver == transform.gameObject).SingleOrDefault().Score += 10;
    }

    private void Update()
    {
        DistanceToNext = DistToNextCheckpoint();
        Ranklist.ScoreList.Where(x => x.Driver == transform.gameObject).SingleOrDefault().DistanceToGo = DistanceToNext;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RankCheckPoint")
        {
            if (other.transform == track.GetCheckpoint(currentIndex))
            {
                Ranklist.ScoreList.Where(x => x.Driver == transform.gameObject).SingleOrDefault().Score += 10;
                if (track.IsFinishLine(currentIndex))
                {
                    currentLap++;


                    if (currentLap >= 3)
                    {
                        // Trigger Racer Finished Here
                    }
                }
                currentIndex = track.GetNextIndex(currentIndex);
            }
        }
    }

    public float DistToNextCheckpoint()
    {
        var nextCheckpoint = track.GetCheckpoint(
            track.GetNextIndex(currentIndex));

        return Vector3.Distance(
            transform.position,
            nextCheckpoint.transform.position
        );
    }
}
