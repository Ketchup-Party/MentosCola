using UnityEngine;

namespace MentosCola {
    /// <summary>当たり判定機</summary>
    public class Splasher : MonoBehaviour {
        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Mentos")) {
                Splash();
                // バグ回避のため入ったメントスは削除する
                Destroy(other.gameObject);
            }
        }

        [SerializeField] GameOnePlayLoopManager gameOnePlayLoopManager = default;
        [SerializeField] ParticleSystem splashParticle = default;
        void Splash() {
            OneTrialResult result = gameOnePlayLoopManager.ChangeToSplash();

            var main = splashParticle.main;
            int startSpeed = result.GetScore() / 50;
            main.startSpeed = new ParticleSystem.MinMaxCurve(startSpeed);

            splashParticle.Play();
        }
    }
}
