using DG.Tweening;
using UnityEngine;

public class AxeTrap : Trap {

    private GameObject axe;
    private void Awake() {
        axe = transform.GetChild(0).gameObject;
    }
    protected override void TweenAnimationOn() {
        axe.transform.DOLocalRotate(Vector3.forward * Parameters.MaxAngle, Parameters.AnimationDuration)
            .SetEase(Parameters.Ease)
            .OnComplete(() => OnTurnOn?.Invoke());
    }

    protected override void TweenAnimationOff() {
        axe.transform.DOLocalRotate(Vector3.back * Parameters.MaxAngle, Parameters.AnimationDuration)
            .SetEase(Parameters.Ease)
            .OnComplete(() => OnTurnOff?.Invoke());
    }
}
