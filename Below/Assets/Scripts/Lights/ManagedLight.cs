using Etienne;
using UnityEngine;

[Requirement(typeof(LightManager)), RequireComponent(typeof(Light))]
public class ManagedLight : MonoBehaviourWithRequirement {
    private new Light light;
    private float baseLightIntensity;
    private LightManager lm;
    private LightAnimation lightAnimation;

    private void Start() {
        lm = LightManager.Instance;
        lm.AddLight(this);
        light = GetComponent<Light>();
        TryGetComponent(out lightAnimation);
        baseLightIntensity = light.intensity;
    }

    private void Update() {
        HandleIntensity();
    }

    public void LightOcclusion() {
        gameObject.SetActive(IsInFalloffRange);
    }

    private void HandleIntensity() {
        light.intensity = GetProximity() * baseLightIntensity * (lightAnimation == null ? 1 : lightAnimation.Intensity);
        LightOcclusion();
    }

    public float GetProximity() {
        if(IsInRange)
            return 1;
        if(IsInFalloffRange) {
            return 1 - (Vector3.Distance(lm.transform.position, transform.position) - lm.Range) / lm.Falloff;
        }
        return 0;
    }

    public bool IsInRange => Vector3.Distance(lm.transform.position, transform.position) <= lm.Range;
    public bool IsInFalloffRange => Vector3.Distance(lm.transform.position, transform.position) <= lm.Range + lm.Falloff;
}
