using Etienne;
using UnityEngine;

[Requirement(typeof(LightManager)), RequireComponent(typeof(Light))]
public class ManagedLight : MonoBehaviourWithRequirement {
    private new Light light;
    private float baseLightIntensity;
    private LightManager lm;
    private LightAnimation lightAnimation;
    private float proximity;

    private void Start() {
        lm = LightManager.Instance;
        lm.AddLight(this);
        light = GetComponent<Light>();
        light = GetComponent<Light>();
        TryGetComponent(out lightAnimation);
        baseLightIntensity = light.intensity;
        HandleIntensity();
    }

    public bool LightOcclusion() {
        gameObject.SetActive(IsInFalloffRange);
        return gameObject.activeInHierarchy;
    }

    public void HandleIntensity() {
        if(!LightOcclusion())
            return;

        proximity = GetProximity();
        RefreshIntensity();
    }

    public void RefreshIntensity() {
        light.intensity = proximity * baseLightIntensity * (lightAnimation == null ? 1 : lightAnimation.Intensity);
    }

    public float GetProximity() {
        if(IsInRange)
            return 1;

        return 1 - (Vector3.Distance(lm.transform.position, transform.position) - lm.Range) / lm.Falloff;
    }

    public bool IsInRange => Vector3.Distance(lm.transform.position, transform.position) <= lm.Range;
    public bool IsInFalloffRange => Vector3.Distance(lm.transform.position, transform.position) <= lm.Range + lm.Falloff;
}
