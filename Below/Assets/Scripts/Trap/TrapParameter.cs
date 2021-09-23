using UnityEngine;

[CreateAssetMenu(fileName = "TrapParameter", menuName = "Trap/Trap parameter")]
public class TrapParameter : ScriptableObject {
    public int Damage => damage;
    public SpikeType SpikeType => spikeType;
    public bool Loop => loop;
    public float AnimationDuration => animationDuration;
    public float TimeBeforeTurningOn => timeBeforeTurningOn;
    public float TimeInBetweenLoops => timeInBetweenLoops;
    public AnimationCurve Ease => ease;

    [SerializeField, Min(0)] private int damage = 5;
    [SerializeField] private SpikeType spikeType;
    [SerializeField] private bool loop = false;
    [SerializeField, Min(0)] private float animationDuration = 1f;
    [SerializeField, Min(0)] private float timeBeforeTurningOn = 0f;
    [SerializeField, Min(0)] private float timeInBetweenLoops = 1f;
    [SerializeField] private AnimationCurve ease;

    public void SetLoop(bool loop) => this.loop = loop;
}
[System.Serializable]
public enum SpikeType { Solo, Multiple }
