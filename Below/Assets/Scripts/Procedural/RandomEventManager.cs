using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventManager : MonoBehaviour
{
    public EventsPlateGestion[] randomEventList;

    public List<int> randomintList = new List<int>();
    public int randomEventsCount = 0;

    void Start()
    {
        randomEventList = FindObjectsOfType<EventsPlateGestion>();
        for (int i = 0; i < randomEventsCount; i++)
        {
            int randomInt = randomRange();
            randomintList.Add(randomInt);
        }
        for (int i = 0; i < randomintList.Count; i++)
        {
            randomEventList[randomintList[i]].RandomPick();

        }
    }

    int randomRange()
    {
        int result= Random.Range(0, randomEventList.Length - 1);
        if(randomintList.Count!=0)
        {
            for (int i = 0; i < randomintList.Count; i++)
            {
                if (randomintList[i] == result)
                {
                    result = randomRange();
                }
            }
        }
        return result;
    }
}
