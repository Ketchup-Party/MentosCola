using UnityEngine;

namespace MentosCola {
    /// <summary>手の動きのインターフェース。</summary>
    public interface IHandMoveStrategy {
        /// <summary>
        /// 準備する
        /// </summary>
        /// <param name="startPosition">手の初期位置</param>
        public void SetUp(Vector3 startPosition);

        /// <summary>
        /// 動かす
        /// </summary>
        /// <param name="transform">手オブジェクトのtransform</param>
        public void Move(Transform transform);
    }
}
