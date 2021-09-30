using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola.Camera {
    /// <summary>
    /// カメラの軌道計算関数まとめ
    /// NOTE: Mathf.Sin(), 引数はラジアン。
    /// </summary>
    public class OrbitCalculator : MonoBehaviour {
        // NOTE: 
        // Vector3用もいる


        // 軌道上に置くカメラを等間隔で配置するための計算関数
        public static Vector2[] GetCameraOrbitOrigins(int cameraNum, float radius, float time, float speed) {
            Vector2[] Origins = new Vector2[cameraNum];
            float angleSpace = 2 * Mathf.PI / cameraNum;
            for (int i = 0; i < cameraNum; i++) {
                Origins[i] = GetCameraPos(Vector2.zero, radius, time, speed);
            }
            return Origins;
        }

        public static Vector2 CalcCirclePolarToRectPos(Vector2 origin, float radius, float theta) {
            return new Vector2(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta));
        }

        public static Vector2 GetCameraPos(Vector2 origin, float radius, float time, float speed) {
            float theta = Mathf.Deg2Rad * time * speed;
            return CalcCirclePolarToRectPos(origin, radius, theta);
        }


    }
}
