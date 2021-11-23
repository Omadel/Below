using System.Collections;
using UnityEngine;

public abstract class Trap : Switchable {
    public TrapParameter Parameters => parameters;
    [SerializeField] protected TrapParameter parameters;
    private Coroutine coroutine;

    private void OnEnable() {
        if(parameters == null || parameters.SpikeType == SpikeType.Multiple) return;
        StartSequence();
    }

    public void StartSequence() {
        if(parameters == null) return;
        coroutine = StartCoroutine(Sequence());
    }

    private void OnDisable() {
        if(coroutine != null) StopCoroutine(coroutine);
    }

    public void SetParameters(TrapParameter parameters) => this.parameters = parameters;

    protected IEnumerator Sequence() {
        if(parameters.Loop) {
            while(true) {
                TurnOn();
                yield return new WaitForSeconds(Mathf.Max(parameters.TimeBeforeTurningOff, parameters.AnimationDuration + parameters.TimeBeforeTurningOff));
                TurnOff();
                yield return new WaitForSeconds(Mathf.Max(parameters.TimeBeforeTurningOn, parameters.AnimationDuration + parameters.TimeBeforeTurningOn));
            }
        } else {
            yield return new WaitForSeconds(parameters.TimeBeforeTurningOn);
            TurnOn();
        }
    }


    public override void TurnOn() {
        if(IsOff) {
            OnStartTransitioning?.Invoke();
            TweenAnimationOn();
        }
    }

    public override void TurnOff() {
        if(IsOn) {
            OnStartTransitioning?.Invoke();
            TweenAnimationOff();
        }
    }

    protected abstract void TweenAnimationOn();

    protected abstract void TweenAnimationOff();
}
