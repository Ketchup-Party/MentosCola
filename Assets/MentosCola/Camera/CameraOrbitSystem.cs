using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola.Camera {
    /// <summary>
    /// カメラの軌道を制御するクラス
    /// イメージは太陽系
    /// 中心に太陽があってその周りを惑星が回ってる
    /// 今回は惑星にカメラを持たせる（カメラは惑星に追従する）
    /// </summary>
    public class CameraOrbitSystem : MonoBehaviour {
        // カメラの座標にしたい惑星（の位置にあたるTransformだけのObject）
        OrbitallyCamera[] orbitallyCamera;
        // 回転速度
        [SerializeField] readonly float planetRotateSpeed = 0.1f;
        // 公転半径
        [SerializeField] readonly float orbitSystemRadius = 10.0f;
        // 公転軸傾き
        [SerializeField] readonly Vector3 revolutionAxis = new Vector3(0.5f, 1f, 0.0f);

        void Awake() {
            orbitallyCamera = this.GetComponentsInChildren<OrbitallyCamera>();
        }

        void Update() {
            // カメラを追従させる点を設定。太陽系で言うなら惑星の位置。
            Vector3[] Origins = OrbitCalculator.GetCameraOrbitOrigins(orbitallyCamera.Length, revolutionAxis, orbitSystemRadius, Time.time, planetRotateSpeed);
            // 惑星の座標を設定
            for (int i = 0; i < orbitallyCamera.Length; i++) {
                orbitallyCamera[i].SetOriginPos(Origins[i]);
            }
        }

        // カメラの座標にしたいObjectの座標を取得する関数
        public Transform[] GetOrbitallyCameras() {
            Transform[] cameras = new Transform[orbitallyCamera.Length];
            for (int i = 0; i < cameras.Length; i++) {
                cameras[i] = orbitallyCamera[i].transform;
            }
            return cameras;
        }
    }
}
