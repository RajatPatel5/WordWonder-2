using UnityEngine;
using UnityEngine.UI;

public class TimeUpScreen : BasePopUp
{
    [SerializeField] Button _playButton;

    private void Start()
    {
        _playButton.onClick.AddListener(OnPlay);
    }

    void OnPlay()
    {
       UiManager.instance.ClosePopUp();
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
        //Time.timeScale = 0;
    }
    public override void DeactivatePopUp()
    {
        base.DeactivatePopUp();
       // Time.timeScale = 1;
    }
}
