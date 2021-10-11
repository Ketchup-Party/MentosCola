using UnityEngine;

namespace MentosCola {
    /// <summary>データ管理クラス</summary>
    public class SaveDataManager : MonoBehaviour {
        string _totalMentosKey = "TotalMentos";
        string _highScoreKey = "HighScore";

        public int GetTotalMentos() {
            int defaultValue = 0; // セーブデータがない場合のデフォルト値
            return PlayerPrefs.GetInt(_totalMentosKey, defaultValue);
        }

        public int GetHighScore() {
            int defaultValue = 0; // セーブデータがない場合のデフォルト値
            return PlayerPrefs.GetInt(_highScoreKey, defaultValue);
        }

        /// <summary>セーブデータのTotalMentosを+1する。</summary>
        public void UpdateTotalMentos() {
            int defaultValue = 0; // セーブデータがない場合のデフォルト値
            int totalMentos = PlayerPrefs.GetInt(_totalMentosKey, defaultValue);

            totalMentos++;
            PlayerPrefs.SetInt(_totalMentosKey, totalMentos);
        }

        /// <summary>
        /// セーブデータのHighScoreを更新する。
        /// </summary>
        /// <param name="highScore">新しいハイスコア</param>
        public void UpdateHighScore(int highScore) {
            int defaultValue = 0; // セーブデータがない場合のデフォルト値
            int previousHighScore = PlayerPrefs.GetInt(_highScoreKey, defaultValue);

            if (previousHighScore > highScore) {
                Debug.LogWarning("ハイスコアじゃないです！");
                return;
            }

            PlayerPrefs.SetInt(_highScoreKey, highScore);
        }

        void DeleteAll() {
            PlayerPrefs.DeleteKey(_totalMentosKey);
            PlayerPrefs.DeleteKey(_highScoreKey);
        }
    }
}
