using System.Collections;
using UnityEngine;

public class MovingWalls : MonoBehaviour
{
    [SerializeField] Transform leftWall;
    [SerializeField] Transform rightWall;

    [SerializeField] Transform left_collisionCheck;
    [SerializeField] Transform right_collisionCheck;

    public float StopRadius = .2f;
    [SerializeField] LayerMask rightWhatIsStop;
    [SerializeField] LayerMask leftWhatIsStop;

    public float _movingRate;

    public bool _stop = false;

    void Start()
    {
        StartCoroutine(MoveWalls());
    }

    private IEnumerator MoveWalls()
    {
        while (!CheckCollision())
        {
            Move();

            yield return new WaitForSeconds(_movingRate);
        }

        Debug.Log("Hit");
    }

    private void Move()
    {
        Vector3 _spaceMove = new Vector3(1, 0f, 0);

        leftWall.position += _spaceMove;
        rightWall.position -= _spaceMove;
    }

    public bool CheckCollision()
	{
        if (Physics2D.OverlapCircle(left_collisionCheck.position, StopRadius, leftWhatIsStop))
            return true;

        if (Physics2D.OverlapCircle(right_collisionCheck.position, StopRadius, rightWhatIsStop))
            return true;

        if (_stop)
            return true;

        Debug.Log("NoHit");

        return false;
	}

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(left_collisionCheck.position, StopRadius);
        Gizmos.DrawWireSphere(right_collisionCheck.position, StopRadius);
    }
}
