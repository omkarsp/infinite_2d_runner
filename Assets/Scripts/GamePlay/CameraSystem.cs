using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform background;
    [SerializeField] private Vector3 cameraStartPos = new Vector3(0, 0, -10);

    private void LateUpdate()
    {
        MoveCamera();
        MoveBackground();
    }

    //Move camera with player
    //Camera will not move backwards
    private void MoveCamera()
    {
        if (player.position.x > transform.position.x && player.localScale.x > 0)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }

    //Move background with camera
    private void MoveBackground()
    {
        background.position = new Vector3(transform.position.x, background.position.y, background.position.z);
    }

    //Move camera to its initial position when game restarts
    public void ResetCamera()
    {
        Debug.Log("Camera reset");
        transform.position = cameraStartPos;
    }
}
