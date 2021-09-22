using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SpikeTrap : Switchable {
    [HideInInspector] public GameObject activator;

    [Header("ScriptableObject")]
    [SerializeField] public SpikeParametre spikeParameter;
    [SerializeField] private AnimationCurve curve;
    private GameObject spikes;

    public bool multipleBool = false, active = false, playOnce = false, utilityBoolenDown = false, trasitionBoolen = false;

    protected override void Start() {
        base.Start();
        spikes = transform.GetChild(1).gameObject;
    }

    private void Update() {
        if(spikeParameter.SpikeType == SpikeType.Solo) {
            if(spikeParameter.Loop) {
                if(active == true && playOnce == false) {
                    playOnce = true;
                    StopCoroutine(SwingDelayed(spikeParameter.TimeBeforeTurningOn));
                    StartCoroutine(SwingDelayed(spikeParameter.TimeBeforeTurningOn));
                }
            } else {

                VerifyActivationAndSpeed();
            }
        } else if(spikeParameter.SpikeType == SpikeType.Multiple) {

            if(utilityBoolenDown == true) {
            }
        }

    }
    private void VerifyActivationAndSpeed() {
        if(active == true) {
            if(utilityBoolenDown == false && trasitionBoolen == false) {
                StartCoroutine(UpWait(spikeParameter.TimeInBetweenLoops));
            } else if(utilityBoolenDown == true && trasitionBoolen == false) {
                StartCoroutine(DownWait(1));
            }
            if(utilityBoolenDown == true) {
            }
        } else {

        }
    }

    private IEnumerator UpWait(float time) {
        trasitionBoolen = true;
        utilityBoolenDown = true;
        yield return new WaitForSeconds(time);


        trasitionBoolen = false;
    }
    public IEnumerator DownWait(float time) {
        trasitionBoolen = true;
        utilityBoolenDown = false;
        yield return new WaitForSeconds(time);
        trasitionBoolen = false;
    }

    private IEnumerator SwingDelayed(float time) {
        yield return new WaitForSeconds(time);
    }

    [ContextMenu("Turn On")]
    public override void TurnOn() {
        if(IsOff) {
            OnStartTransitioning?.Invoke();
            StartCoroutine(WaitToTurnOn());
        }
    }

    [ContextMenu("Turn Off")]
    public override void TurnOff() {
        if(IsOn) {
            OnStartTransitioning?.Invoke();
            StartCoroutine(WaitToTurnOff());
        }
    }

    private IEnumerator WaitToTurnOn() {
        yield return new WaitForSeconds(spikeParameter.TimeBeforeTurningOn);
        spikes.transform.DOMoveY(1, spikeParameter.AnimationDuration)
            .SetEase(curve)
            .OnComplete(() => OnTurnOn?.Invoke());
    }

    private IEnumerator WaitToTurnOff() {
        yield return new WaitForSeconds(spikeParameter.TimeBeforeTurningOn);
        spikes.transform.DOMoveY(0, spikeParameter.AnimationDuration)
            .SetEase(curve)
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
