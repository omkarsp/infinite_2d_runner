using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 1f;
    Material material;
    Camera mainCam;

    public void Init()
    {
        material = GetComponent<Renderer>().material;
        mainCam = Camera.main;
    }

    void Update()
    {
        //float xOffset = Mathf.Max(0, Input.GetAxis("Horizontal"));
        //material.mainTextureOffset += new Vector2(xOffset, 0) * scrollSpeed * Time.deltaTime;

        //float offset = mainCam.velocity.x * scrollSpeed * Time.deltaTime;
        transform.position = new Vector3(mainCam.transform.position.x, transform.position.y, transform.position.z);
        float offset = Mathf.Max(0, Input.GetAxis("Horizontal")) * scrollSpeed * Time.deltaTime;
        material.mainTextureOffset += new Vector2(offset, 0);
    }
}
