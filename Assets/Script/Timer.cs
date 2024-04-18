using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float TotalTime = 60f;
    public TextMeshProUGUI Timer_text;
    private float Time_remaining;
    public Animator Timer_Text_animation;

    // Start is called before the first frame update
    void Start()
    {
        Time_remaining = TotalTime; 
    }

    
    void Update()
    {
        if (Time_remaining <= 12)
        {
            Timer_Text_animation.SetTrigger("Timer_Text");
        }

        if (Time_remaining > 0)
        {
            Time_remaining -= Time.deltaTime;
            Timetext(Time_remaining);
        }
        else
        {
            Timetext(0);
        }

        if(Time_remaining < 0)
        {
            UiManager.instance.OpenPopUp(GamePopUp.TimeUp);
            Time_remaining = 60;
       }
    }

    public void Timetext(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        Timer_text.text = "0"+ minutes + ":" + seconds; 
        
    }
}
