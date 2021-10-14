using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola.Camera {
    /// <summary>
    /// AnimatorCC
    /// Animator Controllerのコントローラー
    /// </summary>
    public class AnimatorCC : MonoBehaviour {
        [SerializeField] Animator animator = default;

        public void OnDrop() {
            animator.SetTrigger("Drop");
        }

        public void OnSuccess() {
            animator.SetTrigger("Success");
        }

        public void OnMiss() {
            animator.SetTrigger("Miss");
        }

        public void OnPlay() {
            animator.SetTrigger("Play");
        }

        public void OnTitle(){
            animator.SetTrigger("Title");
        }

    }
}
