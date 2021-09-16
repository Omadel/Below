using System.Collections.Generic;
using UnityEngine;

public class LightManager : Etienne.Singleton<LightManager> {

    public float Range => range;
    public float Falloff => falloff;

    [Min(0), SerializeField] private float range = 10f, falloff = 3f;
    private List<ManagedLight> lights = new List<ManagedLight>();


    public void AddLight(ManagedLight light) {
        if(lights.Contains(light))
            return;

        lights.Add(light);
    }

    private void Update() {
        if(lights == null)
            return;
        foreach(ManagedLight light in lights) {
            if(!light.gameObject.activeInHierarchy) {
                light.LightOcclusion();
            }
        }
    }

}
