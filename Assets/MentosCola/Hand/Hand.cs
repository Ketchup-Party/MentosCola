using UnityEngine;

namespace MentosCola
{
    /// <summary>メントスを動かす手</summary>
    public class Hand : MonoBehaviour
    {
        float speed = 0.03f;

        void FixedUpdate()
        {
            transform.Translate(speed, 0, 0);
        }
    }
}
