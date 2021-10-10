using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MentosCola.Score {
    /// <summary>スコアを増加させたり減らしたりする関数まとめ</summary>
    public class ScoreCounter {
        public static Tweener IncrementNumberText(int score, int finalValue, float time) {
            return DOTween.To(
            () => score,
            x => score = x,
            finalValue,
            time
            );
        }

    }
}
