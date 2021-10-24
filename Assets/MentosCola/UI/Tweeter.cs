using UnityEngine;
using UnityEngine.Networking;

namespace MentosCola {
    /// <summary>Twitter用クラス</summary>
    public class Tweeter : MonoBehaviour {
        [SerializeField] OneLoopScoreManager oneLoopScoreManager = default;

        /// <summary>
        /// スコアを呟く
        /// </summary>
        public void Tweet() {
            int score = oneLoopScoreManager.GetTotalScore();

            string text = "私のスコアは " + (score).ToString() + " 点でした!\n一緒にはじけませんか？\n";

            string escapedText = UnityWebRequest.EscapeURL(text);
            // string[] hashTags = { "メントスコーラゲーム", "KetchupParty" };
            string[] hashTags = { "メントスコーラゲーム" };

            string escapedHashTag = UnityWebRequest.EscapeURL(hashTags[0]);
            for (int i = 1; i < hashTags.Length; ++i) {
                escapedHashTag += "," + UnityWebRequest.EscapeURL(hashTags[i]);
            }

            string tweetUrl = "https://twitter.com/intent/tweet?text=" + escapedText + "&hashtags=" + escapedHashTag;

            Application.OpenURL(tweetUrl);
        }
    }
}
