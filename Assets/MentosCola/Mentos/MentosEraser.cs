using UnityEngine;

namespace MentosCola {
    /// <summary>メントスを削除する</summary>
    public class MentosEraser : MonoBehaviour {
        /// <summary>
        /// 簡易的なメントス全削除関数です。
        /// ※注意：ゲームプレイシーンで走らせないでください、バグります！
        /// </summary>
        void EraseAllMentoses() {
            GameObject[] allMentos = GameObject.FindGameObjectsWithTag("Mentos");

            foreach (GameObject mentos in allMentos) {
                Destroy(mentos);
            }
        }

        void OnTriggerExit(Collider other) {
            if (other.tag == "Mentos") {
                Debug.Log("範囲外に出たメントスを削除します。");
                Destroy(other.gameObject);
            }
        }
    }
}
