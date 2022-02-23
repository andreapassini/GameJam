using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalls : MonoBehaviour
{
    [SerializeField] Transform leftWall;
    [SerializeField] Transform rightWall;

    public float _movingRate;

    public bool _stop = false;

    void Start()
    {
        StartCoroutine(MoveWalls());
    }

    private IEnumerator MoveWalls()
    {
        while (!_stop)
        {
            Move();

            yield return new WaitForSeconds(_movingRate);
        } 
    }

    private void Move()
    {
        Vector3 _spaceMove = new Vector3(1, 0f, 0);

        leftWall.position += _spaceMove;
        rightWall.position -= _spaceMove;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out MovingWalls tar))
        {
        }
    }
}
