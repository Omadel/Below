using UnityEngine;

[RequireComponent(typeof(ManagedLight))]
public class LightAnimation : MonoBehaviour {
    public float Intensity => intensity;

    [SerializeField] private AnimationCurve intensityCurve;
    private float animationTime, intensity;

    private void Update() {
        animationTime += Time.deltaTime;
        intensity = intensityCurve.Evaluate(animationTime);
    }
}
