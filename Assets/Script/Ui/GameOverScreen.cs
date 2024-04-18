using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : BaseScreen
{
    [SerializeField] Button _restartButton;
    [SerializeField] Button _homeButton;

    private void Start()
    {

        _restartButton.onClick.AddListener(OnRestart);
        _homeButton.onClick.AddListener(OnHome);
    }
    public override void ActivateScreen()
    {
        base.ActivateScreen();
        
    }
    public override void DeactivateScreen()
    {
        base.DeactivateScreen();
    }
    void OnRestart()
    {
        UiManager.instance.ClosePopUp();
        UiManager.instance.SwitchScreen(GameScreens.Play);


    }
    void OnHome()
    {
        UiManager.instance.ClosePopUp();
        UiManager.instance.SwitchScreen(GameScreens.Home);

    }

}
