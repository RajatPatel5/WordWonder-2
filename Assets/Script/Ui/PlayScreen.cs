using UnityEngine;
using UnityEngine.UI;

public class PlayScreen : BaseScreen
{
    [SerializeField] Button _pauseButton;


    private void Start()
    {

        _pauseButton.onClick.AddListener(OnPause);
    }

    void OnPause()
    {

        UiManager.instance.OpenPopUp(GamePopUp.Pause);
    }
    public override void ActivateScreen()
    {
        base.ActivateScreen();
    }
}
