using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MentosCola.Score {
    /// <summary>スコアアニメーションを手順通りにやるクラス</summary>
    public class ScoreAnimator : MonoBehaviour {
        // アニメーションで使う
        [SerializeField] DetailPanelMover detailPanelMover = default;
        [SerializeField] ScoreTextCounter timeTextCounter = default;
        [SerializeField] ScoreTextCounter speedTextCounter = default;
        [SerializeField] ScoreTextCounter distanceTextCounter = default;
        [SerializeField] ScoreTextCounter comboTextCounter = default;
        [SerializeField] ScoreTextCounter currentTrialTextCounter = default;
        [SerializeField] ScoreTextCounter totalScoreTextCounter = default;

        /// <summary>
        /// 結果をアニメーション表示する
        /// 入った時に呼び出す
        /// </summary>
        /// <param name="result"></param>
        public void AnimateScore(OneTrialResult result){
            // 値取得
            float time = (float)result.GetElapsedTimeMilliseconds();
            float speed = result.GetFirstSpeed();
            float distance = result.GetDistanceWhenRelease();
            int currentTrialScore = result.GetScore();

            // パネルを出現させる
            detailPanelMover.DisplayPanel();

            // 点数アニメーション
            AnimateText(time, speed, distance, currentTrialScore);
        }

        /// <summary>
        /// テキスト表示アニメーションの実行をこの関数で担当する
        /// delayTime分遅延させながらアニメーションを開始するようにする
        /// </summary>
        /// <param name="time">時間スコア</param>
        /// <param name="speed">速度スコア</param>
        /// <param name="distance">距離スコア</param>
        void AnimateText(float time, float speed, float distance, int currentTrialScore){
            float delayTime = 1.0f;
            timeTextCounter.IncrementNumber(0.0f, time, delayTime * 0.0f);
            speedTextCounter.IncrementNumber(0.0f, speed, delayTime * 1.0f);
            distanceTextCounter.IncrementNumber(0.0f, distance, delayTime * 2.0f);
            currentTrialTextCounter.IncrementNumber(0.0f, currentTrialScore, delayTime * 3.0f);
            totalScoreTextCounter.IncrementNumber(currentTrialScore, delayTime * 5.0f);
        }
    }
}
