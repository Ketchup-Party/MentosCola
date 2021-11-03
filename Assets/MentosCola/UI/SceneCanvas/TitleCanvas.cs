using UnityEngine;
using UnityEngine.UI;

namespace MentosCola {
    /// <summary>タイトルキャンバス。</summary>
    public class TitleCanvas : MonoBehaviour, IStateSceneCanvas {
        [SerializeField] SaveDataManager saveDataManager = default;

        Canvas canvas;
        [SerializeField] Text totalMentosText = default;
        [SerializeField] Text highScoreText = default;
        void Awake() {
            canvas = GetComponent<Canvas>();
        }

        public void Deactivate() {
            canvas.enabled = false;
        }
        public void Activate() {
            RefreshScoreText();

            canvas.enabled = true;
        }

        /// <summary>
        /// スコアの表示を更新する。
        /// セーブデータを消したときに、外部からここだけ呼びたい。
        /// </summary>
        public void RefreshScoreText(){
            totalMentosText.text = saveDataManager.GetTotalMentos().ToString();
            highScoreText.text = saveDataManager.GetHighScore().ToString();
        }

    }
}
