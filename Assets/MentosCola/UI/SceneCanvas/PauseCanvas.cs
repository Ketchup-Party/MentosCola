using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola {
    /// <summary>ポーズ画面のキャンバス</summary>
    public class PauseCanvas : MonoBehaviour, IStateSceneCanvas {
        Canvas canvas;
        [SerializeField] GameLoopManager gameLoopManager = default;
        void Awake() {
            canvas = GetComponent<Canvas>();
            Deactivate();
        }
        
        public void Deactivate() {
            canvas.enabled = false;
            Time.timeScale = 1.0f;
        }

        public void Activate() {
            canvas.enabled = true;
            Time.timeScale = 0.0f;
        }

        /// <summary>
        /// Go Title ボタン押したら呼ばれる。
        /// </summary>
        public void TitleButtonClick(){
            gameLoopManager.ChangeToTitle();
        }
    }
}
