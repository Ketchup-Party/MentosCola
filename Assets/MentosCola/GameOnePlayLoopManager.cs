using System.Collections;
using UnityEngine;

namespace MentosCola {
    /// <summary>ワンプレイの状態管理。小さいゲームループ。</summary>
    public class GameOnePlayLoopManager : MonoBehaviour {
        enum State {
            NotPlaying,
            Moving,
            Dropping,
            Splash,
            Miss
        }

        State state = State.NotPlaying;

        void ChangeToNotPlaying() {
            Debug.Log("何もしていない状態です。");
            state = State.NotPlaying;
        }

        [SerializeField] Hand hand = default;

        public void ChangeToMoving() {
            Debug.Log("動きました。");
            state = State.Moving;
            hand.StartHaving();
        }

        public void ChangeToDropping() {
            Debug.Log("落としました。");
            if (state != State.Moving) {
                Debug.LogWarning("想定外のゲームループです。");
            }
            state = State.Dropping;
        }

        public void ChangeToSplash() {
            Debug.Log("入りました。");
            if (state != State.Dropping) {
                Debug.LogWarning("想定外のゲームループです。");
            }
            state = State.Splash;

            StartCoroutine(WaitSecondsThenStart(3));
        }

        void ChangeToMiss() {
            Debug.Log("ミスです。");
            if (state != State.Dropping) {
                Debug.LogWarning("想定外のゲームループです。");
            }
            state = State.Miss;

            StartCoroutine(WaitSecondsThenStart(3));
        }

        [SerializeField] MentosManager mentosManager = default;

        [Tooltip("ミスと判定する高さ")]
        [SerializeField] float mentosAltitudeThreshold = -1f;

        // [Tooltip("プレイを終える速度")]
        // [SerializeField] float mentosSpeedThreshold = 0.5f;
        void FixedUpdate() {
            if (state == State.NotPlaying) return;

            if (state == State.Dropping) {
                float mentosAltitude = mentosManager.GetCurrentMentosPos().y;
                if (mentosAltitude < mentosAltitudeThreshold) {
                    ChangeToMiss();
                }
            }
        }

        IEnumerator WaitSecondsThenStart(int waitSeconds) {
            ChangeToNotPlaying();

            yield return new WaitForSeconds(waitSeconds);
            ChangeToMoving();
        }
    }
}
