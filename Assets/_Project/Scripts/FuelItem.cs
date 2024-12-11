using UnityEngine;

namespace Shmup {
    public class FuelItem : Item {
        void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag("Player"))
                {
                other.GetComponent<Player>().AddFuel(amount);
                Destroy(gameObject); 
            }
        }
    }
}