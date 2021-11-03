using System;
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

        // 今回の結果、受け渡し用の変数
        OneTrialResult thisTimeResult = default;

        [SerializeField] Camera.AnimatorCC animatorCC = default;

        [SerializeField] OneLoopScoreManager oneLoopScoreManager = default;
        [SerializeField] SaveDataManager saveDataManager = default;

        // このループでのプレイ回数
        int _playTime = 0;

        // プレイ上限回数
        readonly int _maximumPlayTime = 10;

        // スコアアニメーションするときのクラス
        [SerializeField] Score.ScoreAnimator scoreAnimator = default;

        // ミス判定、成功判定したときの待機時間のコルーチン（あとで止めたい時がある）
        Coroutine waitCoroutine = default;

        public void StartFirstPlay() {
            _playTime = 0;
            oneLoopScoreManager.Reset(_maximumPlayTime);
            scoreAnimator.ResetText();
            ChangeToMoving();
        }


        [SerializeField] Hand hand = default;

        public void ChangeToMoving() {
            Debug.Log("動きました。");
            state = State.Moving;
            hand.StartHaving();
            animatorCC.OnPlay();

            _playTime++;
            saveDataManager.UpdateTotalMentos();
            thisTimeResult = default(OneTrialResult);
        }


        void ChangeToNotPlaying() {
            Debug.Log("何もしていない状態です。");
            state = State.NotPlaying;
        }

        public void ChangeToDropping(OneTrialResult result) {
            Debug.Log("落としました。");
            if (state != State.Moving) {
                Debug.LogWarning("想定外のゲームループです。");
            }
            state = State.Dropping;
            animatorCC.OnDrop();

            thisTimeResult = result;
        }

        public OneTrialResult ChangeToSplash() {
            Debug.Log("入りました。");
            if (state != State.Dropping) {
                Debug.LogWarning("想定外のゲームループです。");
            }
            state = State.Splash;
            animatorCC.OnSuccess();

            bool hasSplashed = true;
            DoScoreProcessing(hasSplashed);
            waitCoroutine = StartCoroutine(WaitSecondsThenStart(3));

            scoreAnimator.AnimateScore(thisTimeResult);

            return thisTimeResult;
        }

        void ChangeToMiss() {
            Debug.Log("ミスです。");
            if (state != State.Dropping) {
                Debug.LogWarning("想定外のゲームループです。");
            }
            state = State.Miss;
            animatorCC.OnMiss();

            bool hasSplashed = false;
            DoScoreProcessing(hasSplashed);
            waitCoroutine = StartCoroutine(WaitSecondsThenStart(3));
        }

        [SerializeField] PauseCanvas pauseCanvas = default;

        void Pause() {
            if (state == State.NotPlaying) return;
            pauseCanvas.Activate();
            Time.timeScale = 0.0f;
        }

        void Resume() {
            pauseCanvas.Deactivate();
            Time.timeScale = 1.0f;
        }

        public void SwitchPause() {
            bool isNotPausing = !Mathf.Approximately(Time.timeScale, 0f);

            if (isNotPausing) {
                Pause();
            }
            else {
                Resume();
            }
        }

        /// <summary>スコア処理をする</summary>
        void DoScoreProcessing(bool hasSplashed) {
            thisTimeResult.SetSuccessResultInfo(hasSplashed, DateTime.Now);
            oneLoopScoreManager.CalculateThisTimeScore(thisTimeResult, _playTime);
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

        [SerializeField] GameLoopManager gameLoopManager = default;
        IEnumerator WaitSecondsThenStart(int waitSeconds) {
            yield return new WaitForSeconds(waitSeconds);

            if (_playTime >= _maximumPlayTime) {
                EndOnePlayLoop();
            }
            else {
                ChangeToMoving();
            }
        }

        /// <summary>１プレイループが終わったら呼び出す。</summary>
        void EndOnePlayLoop() {
            ChangeToNotPlaying();
            int score = oneLoopScoreManager.GetTotalScore();
            gameLoopManager.ChangeToResult(score);
            animatorCC.OnTitle();

            oneLoopScoreManager.EndOnePlayLoop();
        }

        /// <summary>タイトル画面に戻るときに呼び出す。</summary>
        public void ResetPlayLoop() {
            Time.timeScale = 1.0f;
            hand.InitializeState();
            animatorCC.OnTitle();
            ChangeToNotPlaying();
            oneLoopScoreManager.EndOnePlayLoop();

            // ミス判定、成功判定が出た後はコルーチン内の処理が続けられるので、止める。
            if (waitCoroutine != default(Coroutine)) {
                StopCoroutine(waitCoroutine);
                waitCoroutine = default;
            }
            gameLoopManager.ChangeToTitle();
        }
    }
}
