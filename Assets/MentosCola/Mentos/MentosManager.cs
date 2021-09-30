using UnityEngine;

namespace MentosCola {
    /// <summary>メントスのマネージャー。主に現在のメントスを管理する。</summary>
    public class MentosManager : MonoBehaviour {
        [SerializeField] GameObject mentosPref = default;
        GameObject currentMentos = default;

        [SerializeField] Camera.MentosSettingManager mentosSettingManager = default;

        Vector3 firstMentosPosition = new Vector3(0.7f, -1.6f, 0);

        public GameObject CreateMentos(Transform parentTransform) {
            GameObject newMentos = Instantiate(mentosPref, parentTransform);
            newMentos.transform.localPosition = firstMentosPosition;

            currentMentos = newMentos;
            mentosSettingManager.SetMentos(currentMentos);

            return newMentos;
        }

        /// <summary>メントス初速度計算用に前フレームのメントスの位置を記憶</summary>
        Vector3 latestMentosPos = default;
        public Vector3 GetCurrentMentosPos() {
            if (currentMentos == default(GameObject)) {
                Debug.LogWarning("現在メントスが管理下にありません。");
            }

            return currentMentos.transform.position;
        }

        Vector3 currentMentosVelocity = default;

        public Vector3 GetCurrentMentosVelocity() {
            if (currentMentos == default(GameObject)) {
                Debug.LogWarning("現在メントスが管理下にありません。");
            }

            return currentMentosVelocity;
        }

        void FixedUpdate() {
            if (currentMentos == default(GameObject)) return;
            Vector3 currentMentosPosition = currentMentos.transform.position;
            currentMentosVelocity = (currentMentosPosition - latestMentosPos) / Time.fixedDeltaTime;
            latestMentosPos = currentMentosPosition;
        }

    }
}
