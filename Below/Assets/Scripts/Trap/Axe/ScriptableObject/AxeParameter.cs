using UnityEngine;


[CreateAssetMenu(fileName = "AxeParameter", menuName = "Trap/Axe parameter")]
public class AxeParameter : TrapParameter {
    public float MaxAngle => maxAngle;
    [SerializeField] private float maxAngle;

    public override void Initialize(TrapSequenceParameter parameter) {
        base.Initialize(parameter);
        maxAngle = parameter.MaxAngle;
    }
}
