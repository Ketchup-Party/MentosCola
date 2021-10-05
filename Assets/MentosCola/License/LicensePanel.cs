using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MentosCola.Title {
    /// <summary>
    /// ライセンス表示のクラス
    /// 主な機能は表示したライセンスのUIを非表示にすること
    /// NOTE:
    /// IPointerClickHandlerを使った理由
    /// PointerEventDataを直接受け取れるため
    /// </summary>
    public class LicensePanel : MonoBehaviour, IPointerClickHandler {
        public void LicenceViewDisable() {
            this.gameObject.SetActive(false);
        }

        /// <summary>
        /// クリックしたUIがライセンス表記してるUIの外側かどうか確認して、外側だったら非表示にする。
        /// OnPointerClickは上のUIを貫通して呼び出されるため。
        /// このスクリプトをアタッチしてるUIの上（子要素）にライセンス表記UIがある。
        /// </summary>
        public void OnPointerClick(PointerEventData eventData) {
            if (eventData.pointerCurrentRaycast.gameObject == this.gameObject) {
                LicenceViewDisable();
            }
        }

    }
}
