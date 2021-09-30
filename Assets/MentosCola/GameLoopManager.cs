using UnityEngine;

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
            gameOnePlayLoopManager.ChangeToMoving();
        }

        [SerializeField] Canvas resultCanvas = default;
        public void ChangeToResult() {
            state = State.Result;
            ActivateCanvas(resultCanvas);
        }

        public void ChangeToPause() {
            state = State.Pause;
            DeactivateCanvas();
        }
    }
}
