using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola.Camera {
    /// <summary>
    /// カメラの軌道計算関数まとめ
    /// NOTE: Mathf.Sin(), 引数はラジアン。
    /// </summary>
    public class OrbitCalculator {
        // NOTE: 
        // Vector3用もいる
        readonly static float maxDegree = 360.0f;


        // 軌道上に置くカメラを等間隔で配置するための計算関数
        public static Vector3[] GetCameraOrbitOrigins(int cameraNum, Vector3 axis, float radius, float time, float speed) {
            Vector3[] Origins = new Vector3[cameraNum];
            float angleSpace = maxDegree / cameraNum;
            Vector3 circle = CalcCirclePolarToRectPos(radius, time, axis, speed);
            for (int i = 0; i < cameraNum; i++) {
                Origins[i] = Quaternion.AngleAxis(time + angleSpace * i, axis) * circle;
            }
            return Origins;
        }

        [System.Obsolete]
        public static Vector3 CalcCirclePolarToRectPos(float radius, float theta, Vector3 direction, float speed, Vector3 origin) {
            // まずxy平面で円を作成
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta * speed) + origin.x, radius * Mathf.Sin(theta * speed) + origin.y);
            // それを回転させる。xy平面で作るので、絶対に+Z軸方向を見てる。なのでforword(0,0,1)からdirectionを向く回転を作成。
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, direction);
            // 回転させて返す
            return rot * pos;
        }

        public static Vector3 CalcCirclePolarToRectPos(float radius, float theta, Vector3 direction, float speed) {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta * speed), radius * Mathf.Sin(theta * speed));
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, direction);
            return rot * pos;
        }

        public static Vector3 CalcCirclePolarToRectPos(float radius, float theta, Vector3 direction) {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta));
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, direction);
            return rot * pos;
        }

        [System.Obsolete]
        public static Vector3 GetCameraPos(Vector3 origin, float radius, float time, float speed) {
            float theta = Mathf.Deg2Rad * time;
            return CalcCirclePolarToRectPos(radius, theta, Vector3.up, speed, origin);
        }

    }
}
