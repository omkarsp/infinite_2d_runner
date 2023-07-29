using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    Camera mainCam;
    Transform player;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mainCam = Camera.main;
    }

    private void Update()
    {
        DestroyPlatform();
        enemy.EnemyMovement(player);
    }

    //Destroy platform when it goes out of camera view.
    void DestroyPlatform()
    {
        if (mainCam.WorldToViewportPoint(transform.position).x < -1)
        {
            Destroy(gameObject);
        }
    }
}
