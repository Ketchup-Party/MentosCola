using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola.Camera {
    /// <summary>カメラの軌道を制御するクラス</summary>
    public class CameraOrbitSystem : MonoBehaviour {
        Transform[] cameraOrbit;
        void Start() {
            cameraOrbit = this.GetComponentsInChildren<Transform>();
            Debug.Log(cameraOrbit.Length);
        }

        void Update() {
            Vector2[] Origins = OrbitCalculator.GetCameraOrbitOrigins(cameraOrbit.Length, 2.0f, Time.time, 1000.0f);
            for (int i = 0; i < cameraOrbit.Length; i++) {
                // Debug.Log(Origins[i]);
                cameraOrbit[i].position = Origins[i];
            }
        }
    }
}
