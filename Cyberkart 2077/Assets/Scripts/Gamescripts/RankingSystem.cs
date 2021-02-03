using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingSystem : MonoBehaviour
{
    public Transform GetCheckpoint(int index)
    {
        return transform.GetChild(index);
    }

    public int GetNextIndex(int index)
    {
        int nextIndex = index + 1;
        if (nextIndex >= transform.childCount)
        {
            return 0;
        }
        return nextIndex;
    }

    public bool IsFinishLine(int index)
    {
        return transform.childCount - 1 == index;
    }
}

