using UnityEngine;

public class AxeDamager : MonoBehaviour {
    private AxeTrap axeTrap;

    private void Start() {
        axeTrap = GetComponentInParent<AxeTrap>();
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Collide <color=red>!</color>");
        axeTrap.Collide(collision);
    }
}
