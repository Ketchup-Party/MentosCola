using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MentosCola.Title {
    /// <summary>
    /// ライセンスを表示するクラス
    /// </summary>
    public class LicensePopupButton : MonoBehaviour {
        [SerializeField] GameObject licensePanel = default;

        // ボタン押したら呼び出す
        public void LicenceViewEnable() {
            licensePanel.SetActive(true);
        }
    }
}
