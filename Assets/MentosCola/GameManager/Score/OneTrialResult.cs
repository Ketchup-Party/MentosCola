using System;
using UnityEngine; // LogErrorに使用

namespace MentosCola {
    /// <summary>
    /// 一試行の結果を保持するためのクラス。
    /// </summary>
    /// メントスの初速度、
    /// 離した時の距離、
    /// 離してから結果が出るまでの経過時間から、
    /// スコアを算出、保持する。
    public class OneTrialResult {
        // 一試行が終わったか
        bool _hasTrialEnded = false;

        // 初速度。
        float _firstSpeed = default;

        /// <summary>
        /// メントスの初速を返す。
        /// </summary>
        /// <returns>メントスの初速</returns>
        public float GetFirstSpeed() {
            if (!this._hasTrialEnded) {
                Debug.LogWarning("まだ試行が終わっていません。");
            }
            return _firstSpeed;
        }

        // 離した時の距離。
        float _distanceWhenRelease = default;

        /// <summary>
        /// 離した時のメントスの距離を得る。
        /// </summary>
        /// <returns>離した時のメントスの距離</returns>
        public float GetDistanceWhenRelease() {
            if (!this._hasTrialEnded) {
                Debug.LogWarning("まだ試行が終わっていません。");
            }
            return _distanceWhenRelease;
        }
        // 離した時間。
        DateTime _releaseTime;

        // 成功情報
        bool _hasSplashed = false;
        public bool GetHasSplashed() {
            if (!this._hasTrialEnded) {
                Debug.LogError("まだ試行が終わっていないため、成功結果はわかりません。");
                return false;
            }

            return _hasSplashed;
        }

        // 結果算出時の時間
        DateTime _resultTime;

        /// <summary>
        /// 離してから結果が出るまでの経過時間を得る。
        /// </summary>
        /// <returns>離してから結果が出るまでの経過時間（ミリ秒）。</returns>
        public double GetElapsedTimeMilliseconds() {
            if (!this._hasTrialEnded) {
                Debug.LogError("まだ試行が終わっていないため、経過時間はわかりません。");
                return -1;
            }

            return (_resultTime - _releaseTime).TotalMilliseconds;
        }

        int _score;

        public int GetScore() {
            if (!this._hasTrialEnded) {
                Debug.LogError("まだ試行が終わっていないため、成功結果はわかりません。");
                return -1;
            }

            return _score;
        }

        public void SetReleaseInfo(float firstSpeed, float distanceWhenRelease, DateTime releaseTime) {
            this._firstSpeed = firstSpeed;
            this._distanceWhenRelease = distanceWhenRelease;
            this._releaseTime = releaseTime;
        }

        public void SetSuccessResultInfo(bool hasSplashed, DateTime resultTime) {
            this._hasSplashed = hasSplashed;
            this._resultTime = resultTime;

            this._hasTrialEnded = true;
        }

        public int CalculateScore(int consecutiveTime) {
            if (!this._hasTrialEnded) {
                Debug.LogError("まだ試行が終わっていないため、スコアを算出できません。");
                return -1;
            }

            double elapsedMilliSeconds = GetElapsedTimeMilliseconds();

            _score = ScoreCalculator.Calculate(_hasSplashed, (float)elapsedMilliSeconds, _firstSpeed, _distanceWhenRelease, consecutiveTime);
            return _score;
        }
    }
}
