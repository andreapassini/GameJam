using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //end
        GameManager.PlayLvlMainMenu();
    }
}
