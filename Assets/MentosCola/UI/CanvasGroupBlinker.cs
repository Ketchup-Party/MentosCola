using UnityEngine;
using DG.Tweening;

namespace UIUtility
{
    [RequireComponent(typeof(CanvasGroup))]
    /// <summary>アルファ値を上げたり下げたりする。</summary>
    public class CanvasGroupBlinker : MonoBehaviour
    {
        [SerializeField] float loopTime = 1f;
        [SerializeField] Ease ease = Ease.Linear;

        void Start()
        {
            CanvasGroup canvasGroup = GetComponent<CanvasGroup>();

            // 無限に点滅させる
            canvasGroup.DOFade(0f, loopTime)
            .SetEase(this.ease)
            .SetLoops(-1, LoopType.Yoyo);
        }
    }
}
