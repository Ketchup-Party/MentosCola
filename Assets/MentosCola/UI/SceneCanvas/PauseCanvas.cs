using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola {
    /// <summary>ポーズ画面のキャンバス</summary>
    public class PauseCanvas : MonoBehaviour, IStateSceneCanvas {
        Canvas canvas;
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
    }
}
