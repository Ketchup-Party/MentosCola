using UnityEngine;
using UnityEngine.UI;

namespace MentosCola {
    /// <summary>
    /// ゲームループのマネージャー。ゲームループの今どこかを管理する。
    /// 擬似シーン遷移を管理する。
    /// </summary>
    public class GameLoopManager : MonoBehaviour {
        enum State {
            Title,
            Play,
            Result,
            Pause
        }

        State state = State.Title;

        void Awake() {
            resultCanvas.enabled = false;
            ChangeToTitle();
        }

        Canvas _activeCanvas = default;

        void DeactivateCanvas() {
            if (_activeCanvas == default(Canvas)) {
                return;
            }

            _activeCanvas.enabled = false;
            _activeCanvas = default;

        }
        void ActivateCanvas(Canvas canvas) {
            DeactivateCanvas();
            _activeCanvas = canvas;
            _activeCanvas.enabled = true;
        }

        [SerializeField] Canvas titleCanvas = default;

        public void ChangeToTitle() {
            state = State.Title;
            ActivateCanvas(titleCanvas);
        }

        [SerializeField] GameOnePlayLoopManager gameOnePlayLoopManager = default;
        public void ChangeToPlay() {
            state = State.Play;
            DeactivateCanvas();
            gameOnePlayLoopManager.StartFirstPlay();
        }

        [SerializeField] Canvas resultCanvas = default;
        [SerializeField] Text resultScoreText = default;
        public void ChangeToResult(int score) {
            state = State.Result;
            resultScoreText.text = score.ToString();
            ActivateCanvas(resultCanvas);
        }

        public void ChangeToPause() {
            state = State.Pause;
            DeactivateCanvas();
        }
    }
}
