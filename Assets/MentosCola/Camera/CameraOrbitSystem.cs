using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola.Camera {
    /// <summary>カメラの軌道を制御するクラス</summary>
    public class CameraOrbitSystem : MonoBehaviour {
        Planet[] planetCamera;
        [SerializeField] readonly float planetRotateSpeed = 0.1f;
        [SerializeField] readonly float orbitSystemRadius = 10.0f;
        [SerializeField] readonly Vector3 revolutionAxis = new Vector3(0.5f, 1f, 0.0f);

        void Awake() {
            planetCamera = this.GetComponentsInChildren<Planet>();
        }

        void Update() {
            // カメラを追従させる点を設定。太陽系で言うなら惑星の位置。
            Vector3[] Origins = OrbitCalculator.GetCameraOrbitOrigins(planetCamera.Length, revolutionAxis, orbitSystemRadius, Time.time, planetRotateSpeed);
            for (int i = 0; i < planetCamera.Length; i++) {
                planetCamera[i].SetOriginPos(Origins[i]);
            }
        }

        [System.Obsolete]
        Vector3 Vector2toXZ(Vector2 vec2) {
            return new Vector3(vec2.x, 0.0f, vec2.y);
        }

        public Transform[] GetPlanetCameras() {
            Transform[] cameras = new Transform[planetCamera.Length];
            for (int i = 0; i < cameras.Length; i++) {
                cameras[i] = planetCamera[i].transform;
            }
            return cameras;
        }
    }
}
