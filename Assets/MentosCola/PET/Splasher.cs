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
        /// <summary>
        /// パーティクルを吹き出す。
        /// </summary>
        void Splash() {
            OneTrialResult result = gameOnePlayLoopManager.ChangeToSplash();

            // パーティクルの初速
            float startSpeed = result.GetDistanceWhenRelease() * 10;

            // パーティクルの色
            float hue = (Mathf.Max(0, ((float)result.GetElapsedTimeMilliseconds() - 1000)) / 100) % 1.0f;
            Color startColorMin = Color.HSVToRGB(hue, 1, 1);
            Color startColorMax = Color.HSVToRGB((hue + 0.4f) % 1.0f, 1, 1);

            // パーティクルの数
            float rateOverTime = result.GetFirstSpeed() * 100;

            // 初速の設定
            var main = splashParticle.main;
            main.startSpeed = new ParticleSystem.MinMaxCurve(startSpeed);

            // 色の設定
            main.startColor = new ParticleSystem.MinMaxGradient(startColorMin, startColorMax);

            // 数の設定
            var emission = splashParticle.emission;
            float rateOverTimeMinCorrectionValue = 0.75f;
            emission.rateOverTime = new ParticleSystem.MinMaxCurve(rateOverTimeMinCorrectionValue * rateOverTime, rateOverTime);

            splashParticle.Play();
        }
    }
}
