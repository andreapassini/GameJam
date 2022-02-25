using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerMixedUp : MonoBehaviour
{
    public bool GravitySwitch_Up;
    public bool GravitySwitch_Left;
    public bool OrientationSwitch;

    public float GravityForce = 20f;

    private bool _switched = false;

    private Rigidbody2D _rb;
    private Movement _movement;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GravitySwitch_Up)
            Gravity(1);
    }

    public void Gravity(int up)
    {
        if (_switched)
            return;

        if(up == 1) {
            _rb.gravityScale *= -1;
            _switched = true;

            //Rotate the player in order to face upsideDown
            Rotation();
        }
    }

    public void Rotation()
    {
        _rb.freezeRotation = false;
        transform.eulerAngles = new Vector3(0, 0, 180f);

        _rb.freezeRotation = true;

        // y rotation for upsideDown walk
        _movement.facingRight = !_movement.facingRight;
    }
}
