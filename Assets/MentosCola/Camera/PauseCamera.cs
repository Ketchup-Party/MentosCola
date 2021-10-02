using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace MentosCola.Camera {
    /// <summary>タイトル画面、ポーズ画面の時に周回してるカメラ</summary>
    public class PauseCamera : MonoBehaviour {
        CinemachineVirtualCamera cmCamera;
        [SerializeField] CameraOrbitSystem cameraOrbitSystem = default;
        void Awake() {
            cmCamera = GetComponent<CinemachineVirtualCamera>();
        }

        void Start() {
            SetCameraPosition();
        }

        /// <summary>
        /// カメラが追従する座標を設定する
        /// OrbitSystem上で飛んでるカメラをランダムで選んで、設定する
        /// </summary>
        void SetCameraPosition() {
            Transform[] cameras = cameraOrbitSystem.GetOrbitallyCameras();
            int cameraNum = Random.Range(0, cameras.Length);
            cmCamera.Follow = cameras[cameraNum];
        }
    }
}
