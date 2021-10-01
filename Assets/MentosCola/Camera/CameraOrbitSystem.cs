using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola.Camera {
    /// <summary>カメラの軌道を制御するクラス</summary>
    public class CameraOrbitSystem : MonoBehaviour {
        Planet[] planetCamera;
        void Awake() {
            planetCamera = this.GetComponentsInChildren<Planet>();
        }

        void Update() {
            Vector3[] Origins = OrbitCalculator.GetCameraOrbitOrigins(planetCamera.Length, Vector3.up, 10.0f, Time.time, 0.2f);
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
