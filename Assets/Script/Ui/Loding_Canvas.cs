using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Loding_Canvas : BaseScreen
{
    public Slider LoadingSlider;
    bool LodingComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(LoadingSlider.value >= 0.9f && !LodingComplete)
        {
            Debug.Log("Call");
            UiManager.instance.SwitchScreen(GameScreens.Home);
            LodingComplete = true;
        }
    }  
}
