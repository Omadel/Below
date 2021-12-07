using Etienne;
using UnityEngine;

[RequireComponent(typeof(Collider))]
internal class Damager : MonoBehaviour {
    private int damage;

    public void SetDamage(int amount) => this.damage = amount;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            PlayerStats playerstats = other.gameObject.GetComponent<PlayerStats>();
            playerstats.LooseLife(damage, other.transform.position.Direction(playerstats.transform.position).normalized);
        }
    }
}
