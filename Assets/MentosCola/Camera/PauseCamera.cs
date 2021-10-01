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

        void SetCameraPosition() {
            Transform[] cameras = cameraOrbitSystem.GetPlanetCameras();
            int cameraNum = Random.Range(0, cameras.Length);
            cmCamera.Follow = cameras[cameraNum];
        }
    }
}
