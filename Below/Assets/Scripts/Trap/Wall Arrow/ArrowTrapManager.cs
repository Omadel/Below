using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ArrowTrapManager : MonoBehaviour
{
    public List<TempoA> tempos=new List<TempoA>();
    
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
            foreach (TempoA tempo in tempos)
            {
                for (int i = 0; i < tempo.arrowTrapUp.Length; i++)
                {
                    if( tempo.arrowTrapUp[i] != null && tempo.arrowTrapUp[i].arrowParametre.arrowType ==ArrowType.Solo)
                    {
                        tempo.arrowTrapUp[i] = null;
                    }
                }
            }
        }
    }
    IEnumerator CountDown(float time)
    {
        Activable = true;
        yield return new WaitForSeconds(time);

        foreach (ArrowTrap arrow in tempos[tempoCount].arrowTrapUp)
        {
            if (arrow.active == true)
            {
                StartCoroutine(arrow.DownWait(1));
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
public struct TempoA
{
    [SerializeField,Tooltip("in second")]
    public float timeStep;
    [SerializeField]
    public ArrowTrap[] arrowTrapUp;
}
