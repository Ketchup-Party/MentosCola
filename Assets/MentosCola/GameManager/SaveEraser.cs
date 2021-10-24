using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola.Test {
    /// <summary>セーブデータを消して画面を更新する機能</summary>
    public class SaveEraser : MonoBehaviour {
        SaveDataManager saveDataManager;

        void Start(){
            saveDataManager = GameObject.Find("SaveDataManager").GetComponent<SaveDataManager>();
        }

        void Update(){
            if(Input.GetKeyDown(KeyCode.D)){
                DeleteAndRefresh();
            }
        }

        void DeleteAndRefresh(){
            saveDataManager.DeleteAll();
        }
    }
}
