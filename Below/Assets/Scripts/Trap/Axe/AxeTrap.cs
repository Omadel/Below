using DG.Tweening;
using UnityEngine;

public class AxeTrap : Trap {
    [SerializeField] private float maxAngle = 45f;

    private GameObject axe;
    private void Awake() {
        axe = transform.GetChild(0).gameObject;
    }
    protected override void TweenAnimationOn() {
        axe.transform.DOLocalRotate(Vector3.forward * maxAngle, Parameters.AnimationDuration)
            .SetEase(Parameters.Ease)
            .OnComplete(() => OnTurnOn?.Invoke());
    }

    protected override void TweenAnimationOff() {
        axe.transform.DOLocalRotate(Vector3.back * maxAngle, Parameters.AnimationDuration)
            .SetEase(Parameters.Ease)
            .OnComplete(() => OnTurnOff?.Invoke());
    }
}
