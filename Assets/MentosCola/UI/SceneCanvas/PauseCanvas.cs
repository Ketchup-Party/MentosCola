using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola {
    /// <summary>ポーズ画面のキャンバス</summary>
    public class PauseCanvas : MonoBehaviour {
        Canvas canvas;
        [SerializeField] GameOnePlayLoopManager gameOnePlayLoopManager = default;
        void Awake() {
            canvas = GetComponent<Canvas>();
            Deactivate();
        }

        public void Deactivate() {
            canvas.enabled = false;
        }

        public void Activate() {
            canvas.enabled = true;
        }

        /// <summary>
        /// Go Title ボタン押したら呼ばれる。
        /// </summary>
        public void TitleButtonClick() {
            gameOnePlayLoopManager.ResetPlayLoop();
            Deactivate();
        }
    }
}
