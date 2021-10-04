namespace MentosCola {
    /// <summary>点数計算クラス</summary>
    public class ScoreCalculator {

        /// <summary>
        /// 得点計算
        /// リリース時から入るまでの時間 x リリース時のメントスと口の距離 x リリース時の速度
        /// </summary>
        public static int Calculate(bool hasSplashed, float elapsedMilliSeconds, float speed, float distance, int consecutiveTime) {
            if (!hasSplashed) {
                return 0;
            }

            int[] bonus = {
                0,
                10000,
                20000,
                30000,
                40000,
                50000,
                60000,
                70000,
                80000,
                90000
            };

            float score = elapsedMilliSeconds * speed * distance + bonus[consecutiveTime];

            return (int)score;
        }
    }
}
