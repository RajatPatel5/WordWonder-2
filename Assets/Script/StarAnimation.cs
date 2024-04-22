using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarAnimation : MonoBehaviour
{
    public Image DarkStar;
    public Image GoldenStar;

    private Vector3 targetPosition; 
    public float lerpSpeed = 2f; 

    void Start()
    {
        
        targetPosition = DarkStar.transform.position;
    }

    void Update()
    {
        
        GoldenStar.transform.position = Vector3.Lerp(GoldenStar.transform.position, targetPosition, lerpSpeed * Time.deltaTime);
    }
}
