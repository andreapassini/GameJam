using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField] private Animator _animator;

    public MovingWalls MovingWalls;

    private Collider2D _collider2D;

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _animator.SetTrigger("taken");

        MovingWalls.Stop();

        Die();
    }

    public void Die()
    {
        _collider2D.enabled = false;

        MovingWalls.ResetPosition(MovingWalls.MovingRate);

        Destroy(gameObject, time);
    }
}
