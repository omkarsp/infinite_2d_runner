using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform platform;
    [SerializeField] private Transform parent;
    Vector3 groundBlockPosOffset;
    private float platformWidth;
    private Vector3 endPos;

    public void Init()
    {
        platformWidth = platform.Find("road").GetComponent<BoxCollider2D>().size.x;
        Debug.Log(platformWidth);
        groundBlockPosOffset = new Vector3(platformWidth, 0, 0);

        endPos = platform.Find("EndPosition").position + groundBlockPosOffset;
        GenerateInitialBlocks();
    }

    //Spawn platform 5 blocks initially
    private void GenerateInitialBlocks()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnABlock();
        }
    }

    //Spawn block as player moves forward
    internal void SpawnBlocks()
    {
        if (endPos.x - player.position.x < platformWidth * 4)
        {
            SpawnABlock();
        }
    }

    //Spawn single block of platform
    private void SpawnABlock()
    {
        Transform block = Instantiate(platform, endPos, Quaternion.identity);
        block.SetParent(parent);
        endPos = block.Find("EndPosition").position + groundBlockPosOffset;
    }

    //When game restarts destroy all existing blocks
    //First block will not be destroyed
    internal void ResetPlatformGenerator()
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }
}
