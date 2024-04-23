using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarAnimation : MonoBehaviour
{
    public Image DarkStar;
    public Image GoldenStar;

    private Vector3 targetPosition;
    private Vector3 targetScale;
    public float lerpSpeed = 2f; 

    void Start()
    {
        targetScale = DarkStar.transform.localScale;
        Debug.Log(targetScale);
        targetPosition = DarkStar.transform.position;
    }

    void Update()
    {

        Vector3 lerped_Position = Vector3.Lerp(GoldenStar.transform.position, targetPosition, lerpSpeed * Time.deltaTime);
        GoldenStar.transform.position = lerped_Position;

   
        Vector3 lerped_Scale = Vector3.Lerp(GoldenStar.transform.localScale, targetScale, lerpSpeed * Time.deltaTime);
        GoldenStar.transform.localScale = lerped_Scale;
    }
}
    