using System;
using UnityEngine;
using UnityEngine.UI;

namespace MentosCola {
    /// <summary>１プレイループのスコア管理をするクラス。</summary>
    public class OneLoopScoreManager : MonoBehaviour {
        int totalScore = 0;
        public int GetTotalScore() {
            return totalScore;
        }

        // 前回までの連続クリア回数、今回の成功失敗は含まない
        int previouslyConsecutiveTime = 0;

        // プレイ回数の上限。
        int maximumPlayTime;

        [SerializeField] Text splashResultIcons = default;

        OneTrialResult[] results;
        [SerializeField] Canvas oneLoopScoreCanvas = default;

        void Awake() {
            oneLoopScoreCanvas.enabled = false;
        }

        public void Reset(int maximumPlayTime) {
            this.maximumPlayTime = maximumPlayTime;

            totalScore = 0;
            previouslyConsecutiveTime = 0;

            results = new OneTrialResult[maximumPlayTime];
            SetSplashResultIcons();
            oneLoopScoreCanvas.enabled = true;
        }

        /// <summary>一試行分</summary>
        public int CalculateThisTimeScore(OneTrialResult thisTimeResult, int playTime) {
            int score = thisTimeResult.CalculateScore(previouslyConsecutiveTime);
            totalScore += score;

            results[playTime - 1] = thisTimeResult;
            SetSplashResultIcons();

            bool hasSplashed = thisTimeResult.GetHasSplashed();
            if (hasSplashed) {
                previouslyConsecutiveTime += 1;
            }
            else {
                previouslyConsecutiveTime = 0;
            }

            return score;
        }

        void SetSplashResultIcons() {
            char unplayIcon = '-';
            char splashIcon = 'o';
            char missIcon = 'x';

            char[] resultIcons = new char[maximumPlayTime];
            for (int i = 0; i < maximumPlayTime; ++i) {
                if (results[i] == null) {
                    resultIcons[i] = unplayIcon;
                    continue;
                }

                if (results[i].GetHasSplashed()) {
                    resultIcons[i] = splashIcon;
                }
                else {
                    resultIcons[i] = missIcon;
                }
            }

            splashResultIcons.text = new String(resultIcons);
        }

        public int GetPreviouslyConsecutiveTime() {
            return previouslyConsecutiveTime;
        }

        /// <summary>１プレイループが終わったら呼び出す。</summary>
        public void EndOnePlayLoop() {
            oneLoopScoreCanvas.enabled = false;
        }
    }
}
