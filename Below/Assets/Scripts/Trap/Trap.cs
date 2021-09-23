using System.Collections;
using UnityEngine;

public abstract class Trap : Switchable {
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
                yield return new WaitForSeconds(parameters.TimeInBetweenLoops);
                TurnOn();
                yield return new WaitForSeconds(parameters.AnimationDuration);
                TurnOff();
            }
        } else {
            yield return new WaitForSeconds(parameters.TimeBeforeTurningOn);
            TurnOn();
        }
    }


    public override void TurnOn() {
        if(IsOff) {
            StartCoroutine(WaitToTurnOn());
        }
    }

    public override void TurnOff() {
        if(IsOn) {
            StartCoroutine(WaitToTurnOff());
        }
    }

    private IEnumerator WaitToTurnOn() {
        OnStartTransitioning?.Invoke();
        yield return new WaitForSeconds(parameters.TimeBeforeTurningOn);
        TweenAnimationOn();
    }

    protected abstract void TweenAnimationOn();

    protected abstract void TweenAnimationOff();

    private IEnumerator WaitToTurnOff() {
        OnStartTransitioning?.Invoke();
        yield return new WaitForSeconds(parameters.TimeBeforeTurningOn);
        TweenAnimationOn();
    }
}
