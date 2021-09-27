using DG.Tweening;
using UnityEngine;

public class AxeTrap : Trap {
    [SerializeField] private float maxAngle = 45f;

    private GameObject axe;
    private void Awake() {
        axe = transform.GetChild(0).gameObject;
    }
    protected override void TweenAnimationOn() {
        axe.transform.DORotate(Vector3.forward * maxAngle, parameters.AnimationDuration)
            .SetEase(parameters.Ease)
            .OnComplete(() => OnTurnOn?.Invoke());
    }

    protected override void TweenAnimationOff() {
        axe.transform.DORotate(Vector3.back * maxAngle, parameters.AnimationDuration)
            .SetEase(parameters.Ease)
            .OnComplete(() => OnTurnOff?.Invoke());
    }
}
