using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola.Camera {
    /// <summary>
    /// カメラの軌道計算関数まとめ
    /// NOTE: Mathf.Sin(), 引数はラジアン。
    /// </summary>
    public class OrbitCalculator {
        // 円、一周で360度
        readonly static float maxDegree = 360.0f;

        /// <summary>
        /// 軌道上に置くカメラを等間隔で配置するための計算関数
        /// 今回は惑星を同じ軌道上に複数個乗せるようにしている
        /// そのため、カメラの個数にあわせて等間隔で惑星を配置したい
        /// </summary>
        /// <param name="cameraNum">同じ軌道の上にのせるカメラの個数</param>
        /// <param name="axis">公転軸</param>
        /// <param name="radius">公転半径</param>
        /// <param name="time">時間,位置決定に使用。基本はTime.time</param>
        /// <param name="speed">公転速度（角速度）</param>
        /// <returns>原点座標の配列</returns>
        public static Vector3[] GetCameraOrbitOrigins(int cameraNum, Vector3 axis, float radius, float time, float speed) {
            Vector3[] Origins = new Vector3[cameraNum];
            // カメラの個数に応じて、カメラ同士の間隔を計算
            float angleSpace = maxDegree / cameraNum;
            // 円を作る
            Vector3 circle = CalcCirclePolarToRectPos(radius, time, axis, speed);
            // angleSpaceずつずらして（回転させて）原点（カメラ座標）を決定
            for (int i = 0; i < cameraNum; i++) {
                Origins[i] = Quaternion.AngleAxis(time + angleSpace * i, axis) * circle;
            }
            return Origins;
        }

        /// <summary>
        /// 円の座標を計算する
        /// 極座標の円を直交座標の円に変換する
        /// 時間で回転させたいので、時間を引数にして角度を変えると扱いやすいと考えた
        /// </summary>
        /// <param name="radius">半径</param>
        /// <param name="theta">角度</param>
        /// <param name="direction">向き（回転軸）</param>
        /// <param name="speed">速度</param>
        /// <param name="origin">原点</param>
        /// <returns>角度に応じた円周上の点</returns>
        [System.Obsolete]
        public static Vector3 CalcCirclePolarToRectPos(float radius, float theta, Vector3 direction, float speed, Vector3 origin) {
            // まずxy平面で円を作成
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta * speed) + origin.x, radius * Mathf.Sin(theta * speed) + origin.y);
            // それを回転させる。xy平面で作るので、絶対に+Z軸方向を見てる。なのでforword(0,0,1)からdirectionを向く回転を作成。
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, direction);
            // 回転させて返す
            return rot * pos;
        }

        /// <param name="radius">半径</param>
        /// <param name="theta">角度</param>
        /// <param name="direction">向き（回転軸）</param>
        /// <param name="speed">速度</param>
        /// <returns>角度に応じた円周上の点</returns>
        public static Vector3 CalcCirclePolarToRectPos(float radius, float theta, Vector3 direction, float speed) {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta * speed), radius * Mathf.Sin(theta * speed));
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, direction);
            return rot * pos;
        }

        /// <param name="radius">半径</param>
        /// <param name="theta">角度</param>
        /// <param name="direction">向き（回転軸）</param>
        /// <returns>角度に応じた円周上の点</returns>
        public static Vector3 CalcCirclePolarToRectPos(float radius, float theta, Vector3 direction) {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta));
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, direction);
            return rot * pos;
        }

    }
}
