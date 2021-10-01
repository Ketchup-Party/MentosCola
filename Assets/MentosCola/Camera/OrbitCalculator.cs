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

            // 以下Vector3に対応させる。そうしないとy軸周りにしか対応できない。
            Vector2 xyCircle = CalcCirclePolarToRectPos(radius, time, speed);
            Vector3 xzCircle = new Vector3(xyCircle.x, 0.0f, xyCircle.y);

            for (int i = 0; i < cameraNum; i++) {
                Origins[i] = Quaternion.AngleAxis(time + angleSpace * i, axis) * xzCircle;
            }
            return Origins;
        }

        [System.Obsolete]
        public static Vector2 CalcCirclePolarToRectPos(float radius, float theta, float speed, Vector2 origin) {
            return new Vector2(radius * Mathf.Cos(theta * speed) + origin.x, radius * Mathf.Sin(theta * speed) + origin.y);
        }

        [System.Obsolete]
        public static Vector2 CalcCirclePolarToRectPos(float radius, float theta, float speed) {
            return new Vector2(radius * Mathf.Cos(theta * speed), radius * Mathf.Sin(theta * speed));
        }

        [System.Obsolete]
        public static Vector2 CalcCirclePolarToRectPos(float radius, float theta) {
            return new Vector2(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta));
        }

        [System.Obsolete]
        public static Vector2 GetCameraPos(Vector2 origin, float radius, float time, float speed) {
            float theta = Mathf.Deg2Rad * time;
            return CalcCirclePolarToRectPos(radius, theta, speed, origin);
        }

    }
}
