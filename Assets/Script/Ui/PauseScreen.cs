using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class pauseScreen : BasePopUp
{
    [SerializeField] Button _playButton;
    [SerializeField] Button _homeButton;
    public TextMeshProUGUI Timer_text;
    public string ValueofTimerText;
    public Timer Script_Timer;  
   

    private void Start()
    {

        
        ValueofTimerText = Timer_text.text;
        Debug.Log(ValueofTimerText);
        _playButton.onClick.AddListener(OnPlay);
        _homeButton.onClick.AddListener(OnHome);
    }

    void OnPlay()
    {
        Script_Timer.enabled = true;
       UiManager.instance.ClosePopUp();
    }
    void OnHome()
    {
          UiManager.instance.ClosePopUp();
         UiManager.instance.SwitchScreen(GameScreens.Home);
        
        Script_Timer.enabled = false;
        Script_Timer.Time_remaining = 60f;
        //   SceneManager.LoadSceneAsync(0);

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
      //  Time.timeScale = 0;

    }
    public override void DeactivatePopUp()
    {
        base.DeactivatePopUp();
        //  Time.timeScale = 1;

    }
}
