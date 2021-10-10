using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MentosCola.Score {
    /// <summary>詳細スコアのパネルを動かすクラス</summary>
    public class DetailPanelMover : MonoBehaviour {
        RectTransform rect;
        CanvasGroup canvasGroup;

        // アニメーション時間
        float animTime = 0.3f;
        // パネルが上に上がってくるときの距離
        float moveHeight = 20.0f;
        void Start(){
            // transform.DOMoveY(-moveHeight, 0.0f).SetRelative();
            transform.Translate(new Vector3(0.0f, -moveHeight, 0.0f));
            rect = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        /// <summary>
        /// パネルを上げながら見えるようにして、時間がたったら
        /// パネルを下げながら見えなくする関数。
        /// </summary>
        public void DisplayPanel(){
            DOTween.Sequence()
            .Append(transform.DOMoveY(moveHeight, animTime).SetRelative())
            .Join(canvasGroup.DOFade(1.0f, animTime))
            .AppendInterval(5.0f)
            .Append(transform.DOMoveY(-moveHeight, animTime).SetRelative())
            .Join(canvasGroup.DOFade(0.0f, animTime));
        }
    }
}
