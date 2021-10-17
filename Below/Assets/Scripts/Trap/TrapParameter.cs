using UnityEngine;

[CreateAssetMenu(fileName = "TrapParameter", menuName = "Trap/Trap parameter")]
public class TrapParameter : ScriptableObject {
    public int Damage => damage;
    public SpikeType SpikeType => spikeType;
    public bool Loop => loop;
    public float AnimationDuration => animationDuration;
    public float TimeBeforeTurningOn => timeBeforeTurningOn;
    public float TimeBeforeTurningOff => timeBeforeTurningOff;
    public float TimeInBetweenLoops => timeInBetweenLoops;
    public AnimationCurve Ease => ease;

    [SerializeField, Min(0)] private int damage = 5;
    [SerializeField] private SpikeType spikeType;
    [SerializeField] private bool loop = false;
    [SerializeField, Min(0)]
    private float animationDuration = 1f,
        timeBeforeTurningOn = 0f,
        timeBeforeTurningOff = 0f,
        timeInBetweenLoops = 1f;
    [SerializeField] private AnimationCurve ease;

    public virtual void Initialize(TrapSequenceParameter sequence) {
        damage = sequence.Damage;
        spikeType = SpikeType.Multiple;
        loop = sequence.Loop;
        animationDuration = sequence.AnimationDuration;
        timeBeforeTurningOn = sequence.TimeBeforeTurningOn;
        timeBeforeTurningOff = sequence.TimeBeforeTurningOff;
        timeInBetweenLoops = sequence.TimeInBetweenLoops;
        ease = sequence.Ease;
    }

    public void SetLoop(bool loop) {
        this.loop = loop;
    }

    public void SetType(SpikeType spikeType) {
        this.spikeType = spikeType;
    }
}
[System.Serializable]
public enum SpikeType { Solo, Multiple }
