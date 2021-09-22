using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpikeManager : MonoBehaviour
{
    public List<Tempo> tempos=new List<Tempo>();
    
    int tempoCount=0;

    bool Activable = false;

    public void Update()
    {
        if(Application.isPlaying)
        {
            if(Activable==false)
            {

                CountDown(tempos[tempoCount].timeStep);
            }
        }
        else
        {
            foreach (Tempo tempo in tempos)
            {
                for (int i = 0; i < tempo.spikeTrapUp.Length; i++)
                {
                    if( tempo.spikeTrapUp[i] != null && tempo.spikeTrapUp[i].spikeParameter.SpikeType==SpikeType.Solo)
                    {
                        tempo.spikeTrapUp[i] = null;
                    }
                }
            }
        }
    }
    IEnumerator CountDown(float time)
    {
        Activable = true;
        yield return new WaitForSeconds(time);

        foreach (SpikeTrap spike in tempos[tempoCount].spikeTrapUp)
        {
            if (spike.active == true)
            {
                StartCoroutine(spike.DownWait(1));
            }
        }
        tempoCount++;
        if(tempoCount>=tempos.Count)
        {
            tempoCount = 0;
        }
        Activable = false;
    }
}

[System.Serializable]
public struct Tempo
{
    [SerializeField,Tooltip("in second")]
    public float timeStep;
    [SerializeField]
    public SpikeTrap[] spikeTrapUp;
}
