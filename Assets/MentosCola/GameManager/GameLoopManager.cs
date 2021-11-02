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

        void Start() {
            ChangeToTitle();
        }

        [SerializeField] TitleCanvas titleCanvas = default;
        [SerializeField] ResultCanvas resultCanvas = default;
        [SerializeField] PauseCanvas pauseCanvas = default;
        // アクティブキャンバスが一つになるように管理したい
        IStateSceneCanvas _activeStateSceneCanvas = default;

        void DeactivateCanvas() {
            if (_activeStateSceneCanvas == default(IStateSceneCanvas)) {
                return;
            }

            _activeStateSceneCanvas.Deactivate();
            _activeStateSceneCanvas = default;

        }
        void ActivateCanvas(IStateSceneCanvas canvas) {
            DeactivateCanvas();
            _activeStateSceneCanvas = canvas;

            _activeStateSceneCanvas.Activate();
        }

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

        public void ChangeToResult(int score) {
            state = State.Result;
            resultCanvas.SetNewScore(score);
            ActivateCanvas(resultCanvas);
        }

        void ChangeToPause() {
            state = State.Pause;
            ActivateCanvas(pauseCanvas);
        }

        void ChangeFromPause(){
            state = State.Play;
            DeactivateCanvas();
        }

        public void SwitchPause(){
            if(state == State.Play){
                ChangeToPause();
            }else if(state == State.Pause){
                ChangeFromPause();
            }
        }
    }
}
