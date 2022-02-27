using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;

    public bool FollowVertical;
    public bool FollowHorizontal;

     // Update is called once per frame
    void Update()
    {

        if (Player)
        {
            if (FollowHorizontal && FollowVertical)
            {
                transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
                return;
            }


            if (FollowHorizontal)
                transform.position = new Vector3(Player.position.x, transform.position.y, transform.position.z);

            if (FollowVertical)
                transform.position = new Vector3(transform.position.x, Player.position.x, transform.position.z);
        }
        
    }
}
