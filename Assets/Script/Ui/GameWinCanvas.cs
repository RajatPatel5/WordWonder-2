using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWinCanvas : BasePopUp
{

    [SerializeField] Button NextButton;
    // Start is called before the first frame update
    void Start()
    {
        NextButton.onClick.AddListener(OnNextButtonclick);
    }


    public void OnNextButtonclick()
    {
        // UiManager.instance.OpenPopUp(GamePopUp.Win);
        SceneManager.LoadSceneAsync(0);
    }
}
