using System;
using UnityEngine;

namespace MentosCola {
    /// <summary>手をうごかす用</summary>
    public class HandMover : MonoBehaviour {

        // 動きストラテジーリスト
        IHandMoveStrategy[] moveStrategies = {
            new HandWaveStrategy(),
            new HandSimpleVibrationStrategy(),
            new HandCircularMoveStrategy()
        };

        // 今回の動き、ランダムで設定
        int thisTimeMove = 0;

        [SerializeField] Vector3 startPosition = new Vector3(-10, 5, 0);

        public void Reset() {
            this.transform.position = startPosition;

            thisTimeMove = UnityEngine.Random.Range(0, moveStrategies.Length);
            moveStrategies[thisTimeMove].SetUp(startPosition);
        }

        /// <summary>
        /// 手が一定範囲内かどうか判定する。
        /// </summary>
        /// <returns>範囲内ならtrue, 範囲外ならfalse。</returns>
        bool JudgeIsWithinRange() {
            float stageXMin = -100.0f;
            float stageXMax = 100.0f;
            float stageYMin = -100.0f;
            float stageYMax = 100.0f;

            Vector3 handPos = this.gameObject.transform.position;
            if (stageXMin < handPos.x && handPos.x < stageXMax &&
                stageYMin < handPos.y && handPos.y < stageYMax) {
                return true;
            }

            Debug.Log("手が範囲外にあります。");
            return false;
        }

        void FixedUpdate() {
            if (JudgeIsWithinRange()) {
                moveStrategies[thisTimeMove].Move(this.transform);
            }
        }
    }
}
