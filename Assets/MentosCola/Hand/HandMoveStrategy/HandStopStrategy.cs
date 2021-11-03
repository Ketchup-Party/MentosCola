using UnityEngine;

namespace MentosCola {
    /// <summary>何もしない動き</summary>
    public class HandStopStrategy : IHandMoveStrategy {
        Vector3 _startPosition;

        /// <summary>
        /// 準備する
        /// </summary>
        /// <param name="_startPosition">手の初期位置</param>
        public void SetUp(Vector3 startPosition) {
            this._startPosition = startPosition;
        }

        /// <summary>
        /// 動かす（何もしない）
        /// </summary>
        /// <param name="transform">手オブジェクトのtransform</param>
        public void Move(Transform transform) {
            return;
        }
    }
}
