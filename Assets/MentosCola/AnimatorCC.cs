using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MentosCola{
/// <summary>
/// AnimatorCC
/// Animator Controllerのコントローラー
/// </summary>
public class AnimatorCC : MonoBehaviour{
    [SerializeField] Animator animator = default;

    public void OnDrop(){
        animator.SetTrigger("Drop");
    }

    public void OnSuccess(){
        animator.SetTrigger("Success");
    }

    public void OnMiss(){
        animator.SetTrigger("Miss");
    }

    public void OnReset(){
        animator.SetTrigger("Reset");
    }

}
}
