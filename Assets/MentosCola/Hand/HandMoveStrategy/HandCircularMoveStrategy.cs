using UnityEngine;

namespace MentosCola {
    /// <summary>円運動</summary>
    public class HandCircularMoveStrategy : IHandMoveStrategy {
        Vector3 _startPosition;
        float _radius_x;
        float _radius_y;

        /// <summary>
        /// 準備する
        /// </summary>
        /// <param name="startPosition">手の初期位置</param>
        public void SetUp(Vector3 startPosition) {
            this._startPosition = startPosition;
            _radius_x = UnityEngine.Random.Range(4f, 12f);
            _radius_y = UnityEngine.Random.Range(4f, 8f);
        }

        /// <summary>
        /// 動かす
        /// </summary>
        /// <param name="transform">手オブジェクトのtransform</param>
        public void Move(Transform transform) {
            float time = Time.time;

            transform.position = new Vector3(_radius_x * Mathf.Cos(time), _radius_y * Mathf.Sin(time) + _radius_y + _startPosition.y, 0);
        }
    }
}
