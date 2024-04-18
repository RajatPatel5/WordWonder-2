using UnityEngine;
using UnityEngine.UI;

public class pauseScreen : BasePopUp
{
    [SerializeField] Button _playButton;
    [SerializeField] Button _homeButton;

    private void Start()
    {
        _playButton.onClick.AddListener(OnPlay);
        _homeButton.onClick.AddListener(OnHome);
    }

    void OnPlay()
    {
       UiManager.instance.ClosePopUp();
    }
    void OnHome()
    {
        UiManager.instance.ClosePopUp();
        UiManager.instance.SwitchScreen(GameScreens.Home);


    }

    public override void TackInput()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            OnPlay();
        }
    }
    public override void ActivatePopUp()
    {
        base.ActivatePopUp();
       // Time.timeScale = 0;

    }
    public override void DeactivatePopUp()
    {
        base.DeactivatePopUp();
        //  Time.timeScale = 1;

    }
}
