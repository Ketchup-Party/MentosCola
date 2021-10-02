using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola.Camera {
    /// <summary>
    /// 太陽系で例えると惑星の位置にあたるカメラのクラス
    /// 実際には衛星にカメラを持たせたい
    /// </summary>
    public class OrbitallyCamera : MonoBehaviour {
        /// <summary>
        /// TransformのPositionを変更する
        /// </summary>
        /// <param name="originPos">位置</param>
        public void SetOriginPos(Vector3 originPos) {
            transform.localPosition = originPos;
        }
    }
}
