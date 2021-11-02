using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola.Pause {
    /// <summary>ポーズ画面の機能</summary>
    public class PauseManager : MonoBehaviour {
        [SerializeField] GameLoopManager gameLoopManager = default;

        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                gameLoopManager.SwitchPause();
            }
        }
    }
}
