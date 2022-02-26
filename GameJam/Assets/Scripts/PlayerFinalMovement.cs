using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinalMovement : MonoBehaviour
{
    [SerializeField] float speed;

    private float _inputHorizontal;
    private float _inputVertical;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _inputHorizontal = Input.GetAxisRaw("Horizontal");
        _inputVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        transform.position =  new Vector2(transform.position.x + (_inputHorizontal * speed/2f), transform.position.y + ( _inputVertical * speed/2f));
    }
}
