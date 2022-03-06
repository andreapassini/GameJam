 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
public class CursorLight : MonoBehaviour 
{
    public float depth = 10.0f;

    public float GravityRadius;

    void LateUpdate()
    {
        FollowMousePosition();

        if (Input.GetMouseButtonDown(0))
        {

        }
    }
 
    void FollowMousePosition()
    {
        var mousePos = Input.mousePosition;
        var wantedPos = Camera.main.ScreenToWorldPoint( new Vector3(mousePos.x, mousePos.y, depth)); //you need a new vector3 because of the variables it takes XYZ Z= depth
        transform.position = wantedPos;
    }

    IEnumerator C_RadiusRedux()
    {
        var end = Time.time + GravityRadius;
        float _gravityRadius = GravityRadius;
        
        while (Time.time < end)
        {
            transform.localScale = new Vector2(transform.localScale.x - 1f, transform.localScale.y - 1f);
            yield return null;
        }

        _gravityRadius = GravityRadius;
        transform.localScale = new Vector2(GravityRadius, GravityRadius);
    }
}