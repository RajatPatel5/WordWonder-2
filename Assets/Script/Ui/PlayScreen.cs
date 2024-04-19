using UnityEngine;
using UnityEngine.UI;

public class PlayScreen : BaseScreen
{
    [SerializeField] Button _pauseButton;
    public Timer Script_Timer;
   

    private void Start()
    {

        _pauseButton.onClick.AddListener(OnPause);
    }

    void OnPause()
    {
        Script_Timer.enabled = false;
        UiManager.instance.OpenPopUp(GamePopUp.Pause);
       
    }
    public override void ActivateScreen()
    {
        base.ActivateScreen();
    }
}
