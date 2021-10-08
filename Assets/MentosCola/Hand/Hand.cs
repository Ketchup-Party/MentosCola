using System;
using UnityEngine;

namespace MentosCola {
    /// <summary>メントスを動かす手</summary>
    public class Hand : MonoBehaviour {
        enum Status {
            Having,
            Released,
            Stopping,
        }

        Status state = Status.Released;

        [SerializeField] SpriteRenderer handSprite = default;
        [SerializeField] Sprite handOpen = default;
        [SerializeField] Sprite handClose = default;

        GameObject mentos = default;
        [SerializeField] MentosManager mentosManager = default;

        [SerializeField] HandMover handMover = default;

        /// <summary>プレイ開始時</summary>
        public void StartHaving() {
            handSprite.sprite = handClose;
            mentos = mentosManager.CreateMentos(this.gameObject.transform);
            state = Status.Having;
            handMover.Reset();
        }

        void Update() {
            if (Input.GetMouseButtonDown(0)) {
                Release();
            }
        }

        [SerializeField] GameOnePlayLoopManager gameOnePlayLoopManager = default;
        /// <summary>メントスを離す</summary>
        void Release() {
            if (this.state != Status.Having) {
                return;
            }
            else {
                // メントスを離す
                Rigidbody mentosRb = mentos.GetComponent<Rigidbody>();
                mentosRb.isKinematic = false;
                mentosRb.useGravity = true;

                mentos.transform.parent = null;
                Vector3 mentosVelocity = mentosManager.GetCurrentMentosVelocity();
                mentosRb.velocity = mentosVelocity;

                // 手を開ける
                handSprite.sprite = handOpen;
                state = Status.Released;

                // 離した情報を伝達する
                OneTrialResult oneTrialResult = new OneTrialResult();
                float firstSpeed = mentosVelocity.magnitude;
                float distance = Vector3.Distance(mentos.transform.position, splashTargetPoint.transform.position);
                DateTime releaseTime = DateTime.Now;
                oneTrialResult.SetReleaseInfo(firstSpeed, distance, releaseTime);
                gameOnePlayLoopManager.ChangeToDropping(oneTrialResult);
            }
        }
        // 離した距離算出用
        [SerializeField] GameObject splashTargetPoint = default;
    }
}
