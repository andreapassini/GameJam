using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerMixedUp : MonoBehaviour
{
    public bool GravitySwitch_Up;
    public bool GravitySwitch_Left;
    public bool OrientationSwitch;

    public float GravityForce = 20f;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GravitySwitch_Up)
            Gravity(new Vector3(0, 90, 0));

        if (GravitySwitch_Left)
            Gravity(new Vector3(0, 0, 0));

        if (OrientationSwitch)
            SwitchOrientation(new Vector3(0, 0, 0));
    }

    public void Gravity(Vector3 gravityDir)
    {
        //Calcolo la forza di Gravit� come se si fosse sulla terra

        //Trovo il vettore che va dal centro del pianeta al corpo
        // directionToFace = destintion - source
        //Vector3 gravityUp = ((Vector2)_player.position - _mousePosition);

        //Vettore Y del Players
        //Vector3 localUp = _player.up;

        //Applico la forza di attrazione al corpo
        _rb.gravityScale = 0;
        _rb.AddForce(gravityDir.normalized * (_rb.mass * GravityForce));

        ////Ruoto il player in modo che:
        ////      - localUp (il suo asse delle Y) segua la direzione di gravityUp
        //Quaternion targetRotation = Quaternion.FromToRotation(transform.up, gravityDir) * transform.rotation;
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 50f * Time.deltaTime);

        _rb.rotation = 180f;

    }

    public void SwitchOrientation(Vector3 orientationDir)
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(0, 90, 0));
    }
}
