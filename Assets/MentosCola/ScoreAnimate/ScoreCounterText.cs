using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


namespace MentosCola.Score {
    /// <summary>テキストに表示されているスコアを増加させたり減らしたりする機能</summary>
    public class ScoreCounterText : MonoBehaviour {
        enum TYPE {
            INT,
            FLOAT
        }

        Text text;
        float displayScore;
        [SerializeField] float animTime = 0.5f;
        [SerializeField] TYPE displayNumType = TYPE.FLOAT;
        string toStringFormat = default;

        void Start() {
            text = GetComponent<Text>();
            switch (displayNumType) {
                case TYPE.INT:
                    toStringFormat = default;
                    break;
                case TYPE.FLOAT:
                    toStringFormat = default;
                    break;
                default:
                    toStringFormat = default;
                    break;
            }
        }

        void Update() {
            text.text = displayScore.ToString();
        }

        public void IncrementNumber(float currentScore, float finalValue) {
            displayScore = currentScore;
            DOTween.To(
            () => displayScore,
            x => displayScore = x,
            finalValue,
            animTime
            );
        }

    }
}
