using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola.Score {
    /// <summary>スコアアニメーションを手順通りにやるクラス</summary>
    public class ScoreAnimator : MonoBehaviour {
        // 結果を取得するため必要
        [SerializeField] OneTrialResult oneTrialResult = default;

        // アニメーションで使う
        [SerializeField] DetailPanelMover detailPanelMover = default;
        [SerializeField] ScoreCounterText timeText = default;
        [SerializeField] ScoreCounterText speedText = default;
        [SerializeField] ScoreCounterText distanceText = default;


        public void AnimateScore(){
            // 値取得
            float time = (float)oneTrialResult.GetElapsedTimeMilliseconds();
            float speed = oneTrialResult.GetFirstSpeed();
            float distance = oneTrialResult.GetDistanceWhenRelease();

            // パネルを出現させる
            detailPanelMover.DisplayPanel();

            // 点数アニメーション
            timeText.IncrementNumber(0.0f, time);
            speedText.IncrementNumber(0.0f, speed);
            distanceText.IncrementNumber(0.0f, distance);

            // パネルを消す
            detailPanelMover.HidePanel();
        }
    }
}
