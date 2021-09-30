using UnityEngine;

namespace MentosCola {
    /// <summary>当たり判定機</summary>
    public class Splasher : MonoBehaviour {
        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Mentos")) {
                Splash();
            }
        }

        [SerializeField] GameOnePlayLoopManager gameOnePlayLoopManager = default;
        void Splash() {
            gameOnePlayLoopManager.ChangeToSplash();
        }
    }
}
