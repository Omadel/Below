using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SpikeTrap : Switchable {
    [SerializeField] public SpikeParameter parameters;
    private GameObject spikes;
    private Coroutine coroutine;

    protected override void Start() {
        base.Start();
        spikes = transform.GetChild(1).gameObject;
    }

    private void OnEnable() {
        coroutine = StartCoroutine(Sequence());
    }

    private void OnDisable() {
        StopCoroutine(coroutine);
    }


    public IEnumerator Sequence() {
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
        spikes.transform.DOMoveY(1, parameters.AnimationDuration)
            .SetEase(parameters.Ease)
            .OnComplete(() => OnTurnOn?.Invoke());
    }

    private IEnumerator WaitToTurnOff() {
        OnStartTransitioning?.Invoke();
        yield return new WaitForSeconds(parameters.TimeBeforeTurningOn);
        spikes.transform.DOMoveY(0, parameters.AnimationDuration)
            .SetEase(parameters.Ease)
            .OnComplete(() => OnTurnOff?.Invoke());
    }

    protected override void TurnOnAction() {
        SetState(SwitchableState.On);
    }

    protected override void TurnOffAction() {
        SetState(SwitchableState.Off);
    }

    protected override void StartTransitioningAction() {
        SetState(SwitchableState.Transitioning);
    }
}
