using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpikeParameter", menuName = "Trap/Spike parameter")]
public class SpikeParametre : ScriptableObject
{
    public int dommage = 5;
    public float initialSpeed = 1;
    public SpikeType spikeType;
    public bool oneTimeSwing = false;
    public float timeBeforeActivation = 0;
    public float timeDown=1f;
}
[System.Serializable]
public enum SpikeType {Solo,Multiple}
