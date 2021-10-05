using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class AutoFocus : MonoBehaviour {
    [Range(.01f, 15f)] public float focusSpeed = 5f;

    private Volume volume;
    private Vector3 focusPosition;
    private float hitDistance;
    private DepthOfField depthOfField;
    private new Camera camera;

    private void Start() {
        if(!TryGetComponent(out volume)) {
            volume = gameObject.AddComponent<Volume>();
        }
        if(!volume.profile.TryGet(out depthOfField)) {
            depthOfField = volume.profile.Add<DepthOfField>();
        }
        camera = Camera.main;
    }

    private void Update() {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        if(Physics.Raycast(ray, out RaycastHit hit, 100)) {
            focusPosition = hit.point;
            hitDistance = Vector3.Distance(camera.transform.position, hit.point);
        }
        SetFocus();
    }

    private void SetFocus() {
        depthOfField.focusDistance.value = Mathf.Lerp(depthOfField.focusDistance.value, hitDistance, Time.deltaTime * focusSpeed);
    }

    private void OnDrawGizmosSelected() {
        if(camera != null) {
            Gizmos.DrawSphere(focusPosition, .5f);
            Gizmos.DrawLine(camera.transform.position, focusPosition);
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(camera.transform.position + camera.transform.forward * depthOfField.focusDistance.value, .5f);
        }
    }
}
