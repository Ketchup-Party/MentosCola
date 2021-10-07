using System;
using UnityEngine;

namespace MentosCola {
    /// <summary>手をうごかす用</summary>
    public class HandMover : MonoBehaviour {
        // 動きデリゲートのリスト
        Action[] MoveList;

        // 今回の動き、ランダムで設定
        int thisTimeMove = 0;

        [SerializeField] Vector3 startPosition = new Vector3(-10, 5, 0);

        public void Reset() {
            this.transform.position = startPosition;

            thisTimeMove = UnityEngine.Random.Range(0, MoveList.Length);
        }

        // Start is called before the first frame update
        void Awake() {
            MoveList = new Action[]{
                WaveMove,
                SimpleVibrationMove,
                CircularMove
            };
        }

        // Update is called once per frame
        void FixedUpdate() {
            MoveList[thisTimeMove]();
        }

        /// <summary>
        /// 波
        /// </summary>
        void WaveMove() {
            float amplitude = 1f;
            float speed = 0.03f;
            float time = Time.time * 2;
            transform.position = new Vector3(transform.position.x + speed, amplitude * Mathf.Sin(time) + amplitude + startPosition.y, 0);
        }

        /// <summary>
        /// 単振動
        /// </summary>
        void SimpleVibrationMove() {
            float time = Time.time / 2;
            float amplitude = 8f;
            transform.position = new Vector3(amplitude * Mathf.Sin(time), startPosition.y, 0);
        }

        /// <summary>
        /// 円運動
        /// </summary>
        void CircularMove() {
            float time = Time.time;
            float radius_x = 8;
            float radius_y = 4;
            transform.position = new Vector3(radius_x * Mathf.Cos(time), radius_y * Mathf.Sin(time) + radius_y + startPosition.y, 0);
        }
    }
}