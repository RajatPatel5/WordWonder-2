using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Scale_animation : MonoBehaviour, IPointerEnterHandler
{
    //homeCanavs
    public Button PlayButton;

    //GamepLAYCanvas
    //public Button SettingButton;
    public Button PlayPauseButton;

    //pause canvas
    public Button HomeButton;
    public Button ResumeButton;

    //timeUpcanvas
    public Button RetryButton;


    private Vector3 Default_Scale;
    private float Speed;
    private float Increase_Scale;
    private Vector3 Target_Scale;


    private void Start()
    {

        Default_Scale = transform.localScale;
    }


  /*  public void OnMouseOver()
    { 
        IncreaseScale(PlayButton);
      //  IncreaseScale(SettingButton);
        IncreaseScale(PlayPauseButton);
        IncreaseScale(HomeButton);
        IncreaseScale(ResumeButton);
        IncreaseScale(RetryButton);

        
    }*/

    public void IncreaseScale(Button button)
    {   
        Debug.Log("PlayButton");    
        Target_Scale = Default_Scale + Vector3.one * Increase_Scale;
        button.transform.localScale = Vector3.Lerp(button.transform.localScale, Target_Scale, Time.deltaTime * Speed);

    }

    public void Defaultscale(Button button)
    {
        button.transform.localScale = Default_Scale;
    }

    public void OnMouseExit()
    {
        Defaultscale(PlayButton);
       // Defaultscale(SettingButton);
        Defaultscale(PlayPauseButton);
        Defaultscale(HomeButton);
        Defaultscale(ResumeButton);
        Defaultscale(RetryButton);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("hover");
        IncreaseScale(PlayButton);
        //  IncreaseScale(SettingButton);
        IncreaseScale(PlayPauseButton);
        IncreaseScale(HomeButton);
        IncreaseScale(ResumeButton);
        IncreaseScale(RetryButton);
    }
}