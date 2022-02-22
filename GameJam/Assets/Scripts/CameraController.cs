using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;

     // Update is called once per frame
    void Update()
    {
        transform.position = Player.position;
    }
}
