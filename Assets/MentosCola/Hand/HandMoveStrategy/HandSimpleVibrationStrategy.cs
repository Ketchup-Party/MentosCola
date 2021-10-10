using UnityEngine;

namespace MentosCola {
    /// <summary>単振動</summary>
    public class HandSimpleVibrationStrategy : IHandMoveStrategy {
        Vector3 _startPosition = default;
        float _amplitude;
        float _height;

        /// <summary>
        /// 準備する
        /// </summary>
        /// <param name="startPosition">手の初期位置</param>
        public void SetUp(Vector3 startPosition) {
            this._startPosition = startPosition;
            _amplitude = UnityEngine.Random.Range(4f, 12f);
            _height = UnityEngine.Random.Range(0, 5f);
        }

        /// <summary>
        /// 動かす
        /// </summary>
        /// <param name="transform">手オブジェクトのtransform</param>
        public void Move(Transform transform) {
            float time = Time.time / 2;
            transform.position = new Vector3(_amplitude * Mathf.Sin(time), _startPosition.y + _height, 0);
        }
    }
}
