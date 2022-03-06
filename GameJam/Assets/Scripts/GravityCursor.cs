using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravityCursor : MonoBehaviour
{
    public float GravityRadius = 2f;
    public float GravityForce = 20f;

    private float _gravityForce;
    private float _gravityRadius;

    [SerializeField] private Transform _player;

    private Rigidbody2D _rbPlayer;

    private Vector2 _mousePosition;

    private bool _activated = false;

    // Start is called before the first frame update
    void Start()
    {
        _rbPlayer = _player.GetComponent<Rigidbody2D>();
        _gravityForce = GravityForce;
        _gravityRadius = GravityRadius;
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !_activated) 
        {
            _activated = true;
            StartCoroutine(GravityTimer()); 
        }   

    }


    //Calcolo la forza di Gravit� come se si fosse sulla terra
    public void Gravity()
    {
        //Trovo il vettore che va dal centro del pianeta al corpo
        // directionToFace = destintion - source
        Vector3 gravityUp = ((Vector2)_player.position - _mousePosition);

        if (gravityUp.magnitude < _gravityRadius) 
        {
            //Vettore Y del Player
            Vector3 localUp = _player.up;

            //Applico la forza di attrazione al corpo
            _rbPlayer.AddForce(gravityUp.normalized * - (_rbPlayer.mass * _gravityForce));

            ////Ruoto il player in modo che:
            ////      - localUp (il suo asse delle Y) segua la direzione di gravityUp
            //Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * _player.rotation;
            //_player.rotation = Quaternion.Slerp(_player.rotation, targetRotation, 50f * Time.deltaTime);

        }
    }

    private void OnDrawGizmos()
	{
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_mousePosition, _gravityRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_mousePosition, .5f);
	}

    private IEnumerator GravityTimer()
    {
        var end = Time.time + GravityRadius;
        _gravityForce = GravityForce;

        while (Time.time < end)
        {
            Gravity();
            _gravityRadius = end - Time.time;
            yield return null;
        }

        _gravityForce = 0f;
        _gravityRadius = GravityRadius;
        _activated = false;
    }

}
