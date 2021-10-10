using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


namespace MentosCola.Score {
    /// <summary>テキストに表示されているスコアを増加させたり減らしたりする機能</summary>
    public class ScoreTextCounter : MonoBehaviour {
        enum TYPE {
            INT,
            FLOAT
        }

        Text text;
        float displayScore = 0.0f;
        float animTime = 0.8f;
        [SerializeField] TYPE displayNumType = TYPE.FLOAT;
        string toStringFormat = default;

        /// <summary>
        /// この中のswicth文について
        /// 下のUpdateでtextを書き換える際に、ToStringのフォーマットで整数か小数を指定するようにした。
        /// ここでそのフォーマットを決めている。
        /// </summary>
        void Start() {
            text = GetComponent<Text>();
            switch (displayNumType) {
                case TYPE.INT:
                    toStringFormat = "F0";
                    break;
                case TYPE.FLOAT:
                    toStringFormat = "F1";
                    break;
                default:
                    toStringFormat = default;
                    break;
            }
        }

        void Update() {
            text.text = displayScore.ToString(toStringFormat);
        }

        /// <summary>
        /// DOTWeenを使ってカウントをだんだん変えていく関数
        /// </summary>
        /// <param name="firstValue">初めの値</param>
        /// <param name="finalValue">終わりの値</param>
        /// <param name="delayTime">アニメーション開始遅延時間</param>
        public void IncrementNumber(float firstValue, float finalValue, float delayTime) {
            displayScore = firstValue;
            DOTween.Sequence()
            .AppendInterval(delayTime)
            .Append(DOTween.To(
                () => displayScore,
                x => displayScore = x,
                finalValue,
                animTime)
            );
        }

        public void IncrementNumber(float addValue, float delayTime) {
            DOTween.Sequence()
            .AppendInterval(delayTime)
            .Append(DOTween.To(
                () => displayScore,
                x => displayScore = x,
                displayScore + addValue,
                animTime)
            );
        }
    }
}
