using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIController mUIController;
    [SerializeField] PlatformGenerator mPlatformGenerator;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] CameraSystem cameraSystem;

    private void Awake()
    {
        playerMovement.Init();
        mUIController.Init();
        Time.timeScale = 0;
    }

    //Called when Play/Restart button is clicked
    public void ResetGamePlay()
    {
        Time.timeScale = 1;

        //Reset UI
        mUIController.ResetUI();

        //Reset platforms
        mPlatformGenerator.ResetPlatformGenerator();
        mPlatformGenerator.Init();

        //Reset player position
        playerMovement.ResetPlayer();

        //Reset Camera
        cameraSystem.ResetCamera();
    }

    private void Update()
    {
        //Spawn new platforms as player moves forward
        mPlatformGenerator.SpawnBlocks();
    }
}
