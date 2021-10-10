using UnityEngine;

namespace MentosCola {
    /// <summary>メントスを削除する</summary>
    public class MentosEraser : MonoBehaviour {
        void OnTriggerExit(Collider other) {
            if (other.tag == "Mentos") {
                Destroy(other.gameObject);
                Debug.Log("範囲外に出たメントスを削除しました。");
            }
        }
    }
}
