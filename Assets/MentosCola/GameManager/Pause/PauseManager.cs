using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola.Pause {
    /// <summary>ポーズする機能</summary>
    public class PauseManager : MonoBehaviour {
        [SerializeField] GameOnePlayLoopManager gameOnePlayLoopManager = default;

        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                gameOnePlayLoopManager.SwitchPause();
            }
        }
    }
}
