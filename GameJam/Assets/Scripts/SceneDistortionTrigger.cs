using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDistortionTrigger : MonoBehaviour
{
    public GameManager GameManager;

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.PlayLvlFinale();
    }
}
