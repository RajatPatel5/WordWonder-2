using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Scale_animation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button Button;

    private Vector3 Default_Scale;
    public  float Speed;
    public float Increase_Scale;
    private Vector3 Target_Scale;

    private void Start()
    {
        Default_Scale = transform.localScale;
    }

    public void IncreaseScale(Button button)
    {
        
        Target_Scale = Default_Scale + Vector3.one * Increase_Scale;
        button.transform.localScale = Vector3.Lerp(button.transform.localScale, Target_Scale, Time.deltaTime * Speed);
    }

    public void Defaultscale(Button button)
    {
        button.transform.localScale = Default_Scale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IncreaseScale(Button);
        Debug.Log("Hover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Defaultscale(Button);
    }
}
