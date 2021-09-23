using DG.Tweening;
using UnityEngine;

public class SpikeTrap : Trap {
    private GameObject spikes;
    private void Awake() {
        spikes = transform.GetChild(1).gameObject;
    }

    protected override void TweenAnimationOff() {
        spikes.transform.DOMoveY(1, parameters.AnimationDuration)
              .SetEase(parameters.Ease)
              .OnComplete(() => OnTurnOn?.Invoke());
    }

    protected override void TweenAnimationOn() {
        spikes.transform.DOMoveY(0, parameters.AnimationDuration)
             .SetEase(parameters.Ease)
             .OnComplete(() => OnTurnOn?.Invoke());
    }

}
