using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravityCursor : MonoBehaviour
{
    public float GravityRadius = 2f;
    public float GravityForce = 20f;
    private System.Windows.Forms.Timer timer1; 
    private int counter = 60;

    private float _input;

    [SerializeField] private Transform _player;

    private Rigidbody2D _rbPlayer;

    private Vector2 _mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        _rbPlayer = _player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);


    }

	private void FixedUpdate()
	{
        //Trovo il vettore che va dal centro del pianeta al corpo
        // directionToFace = destintion - source
        Vector3 gravityUp = ((Vector2)_player.position - _mousePosition);

        if (gravityUp.magnitude < GravityRadius) 
        {
            //Vettore Y del Player
            Vector3 localUp = _player.up;

            //Applico la forza di attrazione al corpo
            _rbPlayer.AddForce(gravityUp.normalized * -Gravity(_rbPlayer.mass));

            ////Ruoto il player in modo che:
            ////      - localUp (il suo asse delle Y) segua la direzione di gravityUp
            //Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * _player.rotation;
            //_player.rotation = Quaternion.Slerp(_player.rotation, targetRotation, 50f * Time.deltaTime);
        }
    }

    //Calcolo la forza di Gravit� come se si fosse sulla terra
    public float Gravity(float mass)
    {
        float force = mass * GravityForce;

        return force;
    }

    private void OnDrawGizmos()
	{
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_mousePosition, GravityRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_mousePosition, .5f);
	}

    private void Update(){

         _input = Input.GetMouseButton(0);

    }

   
   private void GravityTimer()
   {
        if (_input){

        timer1 = new System.Windows.Forms.Timer();
        timer1.Tick += new EventHandler(timer1_Tick);
        timer1.Interval = 1000; // 1 secondo
        timer1.Start();

        }

    }

    private void TimerTick()
    {
        counter--;
        GravityRadius--;

        if (counter == 0 or _input=false)
            timer1.Stop();

        }

    }

}
