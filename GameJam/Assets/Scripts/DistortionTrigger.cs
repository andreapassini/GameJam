using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistortionTrigger : MonoBehaviour
{

    public GameManager GameManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.PlayLvlDistorted();
    }
}
