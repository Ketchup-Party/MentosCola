using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace MentosCola.Camera {
    /// <summary>注視してほしいメントスをカメラに設定する</summary>
    public class MentosSettingManager : MonoBehaviour {
        [SerializeField] CinemachineVirtualCamera missCamera = default;
        [SerializeField] CinemachineTargetGroup dropMentosTarget = default;

        public void SetMentos(GameObject mentos) {
            RemoveTarget();
            missCamera.Follow = mentos.transform;
            missCamera.LookAt = mentos.transform;
            dropMentosTarget.AddMember(mentos.transform, 1.0f, 0.0f);
        }

        void RemoveTarget() {
            Transform prevMentos = dropMentosTarget.m_Targets[dropMentosTarget.m_Targets.Length - 1].target;
            dropMentosTarget.RemoveMember(prevMentos);
        }
    }
}
