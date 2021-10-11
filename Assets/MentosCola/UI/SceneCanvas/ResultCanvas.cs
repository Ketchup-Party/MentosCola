using UnityEngine;
using UnityEngine.UI;

namespace MentosCola {
    /// <summary>結果表示用キャンバス。</summary>
    public class ResultCanvas : MonoBehaviour, IStateSceneCanvas {
        [SerializeField] SaveDataManager saveDataManager = default;

        Canvas canvas;
        [SerializeField] Text resultScoreText = default;
        void Awake() {
            canvas = GetComponent<Canvas>();
            Deactivate();
        }

        public void Deactivate() {
            canvas.enabled = false;
        }

        int newScore = 0;
        public void SetNewScore(int score) {
            this.newScore = score;
        }

        public void Activate() {
            int currentHighScore = saveDataManager.GetHighScore();
            if (newScore > currentHighScore) {
                Debug.Log("ハイスコアです。");
                saveDataManager.UpdateHighScore(newScore);
            }
            resultScoreText.text = newScore.ToString();

            canvas.enabled = true;
        }
    }
}
