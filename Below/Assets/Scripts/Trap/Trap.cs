using System.Collections;
using UnityEngine;

public abstract class Trap : Switchable  {
    [SerializeField] public TrapParameter parameters;
    private Coroutine coroutine;

    private void OnEnable() {
        coroutine = StartCoroutine(Sequence());
    }

    private void OnDisable() {
        StopCoroutine(coroutine);
    }


    protected IEnumerator Sequence() {
        if(parameters.Loop) {
            while(true) {
                TurnOn();
                yield return new WaitForSeconds(Mathf.Max(parameters.TimeInBetweenLoops, parameters.AnimationDuration + parameters.TimeInBetweenLoops));
                TurnOff();
                yield return new WaitForSeconds(Mathf.Max(parameters.TimeInBetweenLoops, parameters.AnimationDuration + parameters.TimeInBetweenLoops));
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
            //StartCoroutine(WaitToTurnOn());
        }
    }

    public override void TurnOff() {
        if(IsOn) {
            OnStartTransitioning?.Invoke();
            TweenAnimationOff();
            //StartCoroutine(WaitToTurnOff());
        }
    }

    private IEnumerator WaitToTurnOn() {
        yield return new WaitForSeconds(parameters.TimeBeforeTurningOn);
    }

    protected abstract void TweenAnimationOn();

    protected abstract void TweenAnimationOff();

    private IEnumerator WaitToTurnOff() {
        yield return new WaitForSeconds(parameters.TimeBeforeTurningOn);
    }
}
