using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistortionTrigger : MonoBehaviour
{

    public Animator Animator;   

    void Update()
    {
        Animator.SetTrigger("distortion");
    }
}
