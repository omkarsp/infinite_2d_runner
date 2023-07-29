using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemySpeed = 1f;
    float localScaleX;
    Camera mainCam;

    private void OnEnable()
    {
        mainCam = Camera.main;
        localScaleX = transform.localScale.x;
    }

    //Enemy keeps moving and facing towards player with constant speed
    public void EnemyMovement(Transform playerTransform)
    {
        if (transform.position.x > playerTransform.position.x)
        {
            transform.position += Vector3.left * enemySpeed * Time.deltaTime;
            transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.position += Vector3.right * enemySpeed * Time.deltaTime;
            transform.localScale = new Vector3(-localScaleX, transform.localScale.y, transform.localScale.z);
        }
    }
}
