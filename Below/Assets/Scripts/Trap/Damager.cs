using UnityEngine;

[RequireComponent(typeof(Collider))]
internal class Damager : MonoBehaviour {
    [SerializeField] private int damage;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            PlayerStats playerstats = other.gameObject.GetComponent<PlayerStats>();
            playerstats.LooseLife(damage);
        }
    }
}
