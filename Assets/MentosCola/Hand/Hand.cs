using UnityEngine;

namespace MentosCola
{
    /// <summary>メントスを動かす手</summary>
    public class Hand : MonoBehaviour
    {
        enum Status
        {
            Moving,
            Stopping
        }

        Status state = Status.Moving;
        [SerializeField] GameObject mentos = default;

        /// <summary>メントス初速度計算用に前フレームのメントスの位置を記憶</summary>
        Vector3 latestMentosPos = default;
        void Awake()
        {
            latestMentosPos = mentos.transform.position;
        }

        Vector3 mentosInitialVelocity = default;
        float speed = 0.03f;

        void FixedUpdate()
        {
            if (this.state == Status.Moving)
            {
                transform.Translate(speed, 0, 0, Space.World);
                float _current_rotation_speed = Mathf.Sin(3 * Time.time);
                transform.Rotate(0, 0, _current_rotation_speed);

                mentosInitialVelocity = (mentos.transform.position - latestMentosPos) / Time.fixedDeltaTime;
                latestMentosPos = mentos.transform.position;
            }
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Release();
            }
        }

        /// <summary>メントスを離す</summary>
        void Release()
        {
            Rigidbody mentosRb = mentos.GetComponent<Rigidbody>();
            mentosRb.isKinematic = false;
            mentosRb.useGravity = true;

            mentos.transform.parent = null;
            mentosRb.velocity = mentosInitialVelocity;
        }
    }
}
