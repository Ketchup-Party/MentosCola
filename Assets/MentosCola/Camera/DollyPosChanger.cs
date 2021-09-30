using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola.Test {
    /// <summary>DollyPosを無理やり動かす</summary>
    public class DollyPosChanger : MonoBehaviour {
        [SerializeField] Cinemachine.CinemachineVirtualCamera cmcamera = default;

        void Update() {
            cmcamera.GetCinemachineComponent<Cinemachine.CinemachineTrackedDolly>().m_PathPosition += 0.0002f;
        }
    }
}
