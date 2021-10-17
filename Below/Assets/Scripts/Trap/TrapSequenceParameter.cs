using UnityEngine;

[CreateAssetMenu(fileName = "TrapSequenceParameter", menuName = "Trap/Sequence parameter")]
public class TrapSequenceParameter : ScriptableObject {
    public int Damage => damage;
    public bool Loop => loop;
    public float AnimationDuration => animationDuration;
    public float TimeBeforeTurningOn => timeBeforeTurningOn;
    public float TimeBeforeTurningOff => timeBeforeTurningOff;
    public float TimeInBetweenLoops => timeInBetweenLoops;
    public AnimationCurve Ease => ease;
    public float MaxAngle => maxAngle;
    public float TimeBetweenTraps => timeBetweenTraps;

    [SerializeField, Min(0)] private int damage = 5;
    [SerializeField] private bool loop = false;
    [SerializeField, Min(0)]
    private float animationDuration = 1f,
        timeBeforeTurningOn = 0f,
        timeBeforeTurningOff = 0f,
        timeInBetweenLoops = 1f,
        timeBetweenTraps;
    [SerializeField] private AnimationCurve ease;
    [SerializeField] private float maxAngle;
}
