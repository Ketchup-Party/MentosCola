using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola {
    /// <summary>セーブデータ削除確認キャンバス</summary>
    public class DataResetPanel : MonoBehaviour {
        [SerializeField] SaveDataManager saveDataManager = default;
        [SerializeField] TitleCanvas titleCanvas = default;

        /// <summary>
        /// タイトル画面の「Reset Data」押したら呼ばれる。
        /// </summary>
        public void EnablePopup(){
            this.gameObject.SetActive(true);
        }

        public void ClickNoButton(){
            this.gameObject.SetActive(false);
        }

        public void ClickYesButton(){
            saveDataManager.DeleteAll();
            titleCanvas.RefreshScoreText();
            this.gameObject.SetActive(false);
        }
    }
}
