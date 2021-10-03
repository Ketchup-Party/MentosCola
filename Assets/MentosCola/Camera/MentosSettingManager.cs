using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace MentosCola.Camera {
    /// <summary>注目してほしいメントスをカメラに設定する</summary>
    public class MentosSettingManager : MonoBehaviour {
        // ミスしたときにメントスを追いかけるカメラ
        [SerializeField] CinemachineVirtualCamera missCamera = default;
        // メントス落とすときのペットボトルの先とメントスを見るTargetGroup
        [SerializeField] CinemachineTargetGroup dropMentosTarget = default;

        /// <summary>
        /// 注目するメントスを設定する
        /// </summary>
        /// <param name="mentos">現在操作中のメントス</param>
        public void SetMentos(GameObject mentos) {
            // 前のメントスをTargetGroupから外す
            RemoveTarget();
            // 注目するメントスを設定
            missCamera.Follow = mentos.transform;
            missCamera.LookAt = mentos.transform;
            dropMentosTarget.AddMember(mentos.transform, 1.0f, 0.0f);
        }

        /// 前のメントスをTargetGroupから外す
        void RemoveTarget() {
            Transform prevMentos = dropMentosTarget.m_Targets[dropMentosTarget.m_Targets.Length - 1].target;
            dropMentosTarget.RemoveMember(prevMentos);
        }
    }
}
