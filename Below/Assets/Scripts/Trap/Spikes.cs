using DG.Tweening;
using UnityEngine;

public class Spikes : MonoBehaviour {
    [SerializeField] private new AnimationCurve animation;

    private GameObject spikes;
    private bool isBeingAnimated;

    private void Start() {
        spikes = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    private void Update() {
    }

    [ContextMenu("SwitchOn")]
    public void SwitchOn() {
        if(isBeingAnimated)
            return;

        isBeingAnimated = true;
        spikes.transform.DOMoveY(1, .4f).OnComplete(() => isBeingAnimated = false).SetEase(animation);
    }

    [ContextMenu("SwitchOff")]
    public void SwitchOff() {
        if(isBeingAnimated)
            return;

        isBeingAnimated = true;
        spikes.transform.DOMoveY(0, .4f).OnComplete(() => isBeingAnimated = false).SetEase(animation);

    }
}
