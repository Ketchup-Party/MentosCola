using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola.Camera {
    /// <summary>
    /// 惑星の位置にあたるカメラのクラス
    /// 実際には衛星にカメラを持たせる
    /// </summary>
    public class Planet : MonoBehaviour {
        public void SetOriginPos(Vector3 originPos) {
            transform.localPosition = originPos;
        }
    }
}
