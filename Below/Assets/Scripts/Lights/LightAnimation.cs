using UnityEngine;

[RequireComponent(typeof(ManagedLight))]
public class LightAnimation : MonoBehaviour {
    public float Intensity => intensity;

    [SerializeField] private AnimationCurve intensityCurve;
    private float animationTime, intensity;
    private ManagedLight managedLight;

    private void Start() {
        managedLight = GetComponent<ManagedLight>();
    }

    private void Update() {
        animationTime += Time.deltaTime;
        intensity = intensityCurve.Evaluate(animationTime);
        managedLight.RefreshIntensity();
    }
}
