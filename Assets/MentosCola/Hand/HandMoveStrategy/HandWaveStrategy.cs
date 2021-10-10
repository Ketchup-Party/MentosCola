using UnityEngine;

namespace MentosCola {
    /// <summary>波の動き</summary>
    public class HandWaveStrategy : IHandMoveStrategy {
        Vector3 _startPosition;
        float _amplitude;
        float _speed;

        /// <summary>
        /// 準備する
        /// </summary>
        /// <param name="_startPosition">手の初期位置</param>
        public void SetUp(Vector3 startPosition) {
            this._startPosition = startPosition;
            _amplitude = UnityEngine.Random.Range(0, 2.0f);
            _speed = UnityEngine.Random.Range(0.03f, 0.07f);
        }

        /// <summary>
        /// 動かす
        /// </summary>
        /// <param name="transform">手オブジェクトのtransform</param>
        public void Move(Transform transform) {
            float time = Time.time * 2;
            transform.position = new Vector3(transform.position.x + _speed, _amplitude * Mathf.Sin(time) + _amplitude + _startPosition.y, 0);
        }
    }
}
