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

    public float MovingRate;

    public bool _stop = false;

    private Vector3 _startingPosLeft;
    private Vector3 _startingPosRight;

    private float _startingMovingRate;
    private int _countPoints = 0;

    [SerializeField] private HealthController _player;

    void Start()
    {
        _startingMovingRate = MovingRate;

        _startingPosLeft = new Vector3(leftWall.position.x, leftWall.position.y, 0);
        _startingPosRight = new Vector3(rightWall.position.x, rightWall.position.y, 0);

        StartCoroutine(MoveWalls());
    }

    private void Update()
    {
        
    }

    private IEnumerator MoveWalls()
    {
        while (!CheckCollision())
        {
            Move();

            yield return new WaitForSeconds(MovingRate);
        }

        _player.Die();

        if(_countPoints < 3)
        {
            // Restart from level 1
            GameManager.PlayStartScene();
        }

        if (_countPoints == 3)
        {
            // Go to last level
            GameManager.PlayLvlFinale();
        }
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

        return false;
	}

    public void ResetPosition(float movingRate) 
    {
        leftWall.position = _startingPosLeft;
        rightWall.position = _startingPosRight;

        MovingRate = movingRate;

        _stop = false;

        _countPoints++;
    }

    public void Stop()
    {
        _stop = true;
    }
}
