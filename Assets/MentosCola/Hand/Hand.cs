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

        [SerializeField] Vector3 startPosition = new Vector3(-10, 4, 0);

        GameObject mentos = default;
        [SerializeField] MentosManager mentosManager = default;

        /// <summary>プレイ開始時</summary>
        public void StartHaving() {
            handSprite.sprite = handClose;
            this.transform.position = startPosition;
            mentos = mentosManager.CreateMentos(this.gameObject.transform);
            state = Status.Having;
        }

        float speed = 0.03f;

        void FixedUpdate() {
            if (this.state == Status.Stopping) return;

            transform.Translate(speed, 0, 0, Space.World);
            float _current_rotation_speed = Mathf.Sin(3 * Time.time);
            transform.Rotate(0, 0, _current_rotation_speed);
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
