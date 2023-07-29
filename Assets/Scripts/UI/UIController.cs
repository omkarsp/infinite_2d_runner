using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject mainMenuScreen;
    [SerializeField] GameObject hudScreen;
    [SerializeField] GameObject gameOverScreen;

    [SerializeField] HudHandler hudHandler;
    //[SerializeField] BackgroundScroll backgroundScroll;

    public void Init()
    {
        ShowMainMenu(true);
        //backgroundScroll.Init();
    }

    public void ShowMainMenu(bool value)
    {
        mainMenuScreen.SetActive(value);
    }

    public void ShowGameOverScreen(bool value)
    {
        gameOverScreen.SetActive(value);
    }

    public void ShowHud(bool value)
    {
        hudScreen.SetActive(true);
    }

    public void MainMenuButtonClicked()
    {
        ShowMainMenu(true);
        ShowGameOverScreen(false);
    }

    public void ResetUI()
    {
        hudHandler.ResetHud();//Reset Player Stats
        ShowHud(true);
        ShowGameOverScreen(false);
        ShowMainMenu(false);
    }
}
