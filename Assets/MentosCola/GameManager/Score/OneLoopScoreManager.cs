using UnityEngine;
using UnityEngine.UI;

namespace MentosCola {
    /// <summary>１プレイループのスコア管理をするクラス。</summary>
    public class OneLoopScoreManager : MonoBehaviour {
        int totalScore = 0;

        // 前回までの連続クリア回数、今回の成功失敗は含まない
        int previouslyConsecutiveTime = 0;

        [SerializeField] Text scoreText = default;
        public void Reset() {
            totalScore = 0;
            previouslyConsecutiveTime = 0;

            scoreText.text = totalScore.ToString();
        }


        /// <summary>一試行分</summary>
        public int CalculateThisTimeScore(OneTrialResult thisTimeResult) {
            int score = thisTimeResult.CalculateScore(previouslyConsecutiveTime);
            totalScore += score;

            if (thisTimeResult.GetHasSplashed()) {
                previouslyConsecutiveTime += 1;
            }
            else {
                previouslyConsecutiveTime = 0;
            }

            scoreText.text = totalScore.ToString();
            return score;
        }

    }
}
