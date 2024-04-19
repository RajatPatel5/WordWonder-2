using UnityEngine;
using UnityEngine.UI;

public class HomeScreen : BaseScreen
{
    [SerializeField] Button _playButton;
    public Timer Script_Timer;

    private void Start()
    {

        _playButton.onClick.AddListener(OnPlay);
    }
    public override void ActivateScreen()
    {
        base.ActivateScreen();
    }
    void OnPlay()
    {
        Script_Timer.enabled = true;
        UiManager.instance.SwitchScreen(GameScreens.Play);
    }
}
