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
        float moveHeight = 100.0f;
        void Start(){
            rect = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void DisplayPanel(){
            DOTween.Sequence()
            .Append(rect.DOLocalMoveY(-moveHeight, animTime).SetRelative())
            .Join(canvasGroup.DOFade(1.0f, animTime));
        }

        public void HidePanel(){
            DOTween.Sequence()
            .Append(rect.DOLocalMoveY(moveHeight, animTime).SetRelative())
            .Join(canvasGroup.DOFade(0.0f, animTime));
        }
    }
}
