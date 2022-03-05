using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{

    public Transform LevelLoader; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //end
        LevelLoader.GetComponent<GameManager>().PlayLvlMainMenu();
    }
}
