using System;
using UnityEngine;

namespace MentosCola {
    /// <summary>手をうごかす用</summary>
    public class HandMover : MonoBehaviour {
        // 動きデリゲートのリスト
        Action[] MoveList;

        // 今回の動き、ランダムで設定
        int thisTimeMove;

        [SerializeField] Vector3 startPosition = new Vector3(-10, 5, 0);

        public void Reset() {
            this.transform.position = startPosition;

            thisTimeMove = UnityEngine.Random.Range(0, MoveList.Length);
        }

        // Start is called before the first frame update
        void Awake() {
            MoveList = new Action[]{
            // UniformLinearMove,
            SimpleVibrationMove,
            WaveMove,
            CircularMove
        };
            Reset();
        }

        // Update is called once per frame
        void FixedUpdate() {
            MoveList[thisTimeMove]();
        }

        // /// <summary>
        // /// 等速直線運動、反復あり
        // /// </summary>
        // void UniformLinearMove(){
        //     float x = this.transform.position.x;
        //     float speed = 0.03f;
        //     if(x < 5){
        //         transform.Translate(speed, 0, 0, Space.World);
        //     }else {
        //         transform.Translate(-speed, 0, 0, Space.World);
        //         Debug.Log(-speed);
        //     }
        // }

        /// <summary>
        /// 単振動
        /// </summary>
        void SimpleVibrationMove() {
            float time = Time.time;
            float amplitude = 8f;
            transform.position = new Vector3(amplitude * Mathf.Sin(Time.time), startPosition.y, 0);
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
        /// 円運動
        /// </summary>
        void CircularMove() {
            float time = Time.time;
            float radius_x = 5;
            float radius_y = 2;
            transform.position = new Vector3(radius_x * Mathf.Cos(time), radius_y * Mathf.Sin(time) + radius_y + startPosition.y, 0);
        }
    }
}
