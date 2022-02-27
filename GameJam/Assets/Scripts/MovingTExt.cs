using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTExt : MonoBehaviour
{
    private bool _leftMove = false;

    public Vector3 Space;

    private void Start()
    {
        Space = new Vector3(1f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        

       
        Move();
    }

    public void Move()
    {
        if(_leftMove)
            transform.position += Space;

    }
}
