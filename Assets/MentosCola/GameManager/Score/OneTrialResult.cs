using System;
using UnityEngine; // LogErrorに使用

namespace MentosCola {
    /// <summary>一試行の結果を受け渡しするためのデータ保持用クラス。</summary>
    public class OneTrialResult {
        // 一試行が終わったか
        bool _hasTrialEnded = false;

        // 初速度。
        float _firstSpeed;
        // 離した時の距離。
        float _distanceWhenRelease;
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

        // 結果算出時間
        DateTime _resultTime;

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

            double elapsedMilliSeconds = (_resultTime - _releaseTime).TotalMilliseconds;
            return ScoreCalculator.Calculate(_hasSplashed, (float)elapsedMilliSeconds, _firstSpeed, _distanceWhenRelease, consecutiveTime);
        }
    }
}
