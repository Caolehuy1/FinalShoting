using UnityEngine;

namespace Shmup {
    public class HealthItem : Item {
        void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<Player>().AddHealth((int)amount);
                Destroy(gameObject);
            }
        }
    }
}