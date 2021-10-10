using UnityEngine;

public class Ladder : MonoBehaviour {
    private BoxCollider trigger;

    private void Awake() {
        trigger = GetComponent<BoxCollider>();
        trigger.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent(out CMF.AdvancedWalkerController walker)) {
            walker.SetClimbing(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.TryGetComponent(out CMF.AdvancedWalkerController walker)) {
            walker.SetClimbing(false);
        }
    }
}
