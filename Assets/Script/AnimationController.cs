using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public GameObject Rock;
    public TextMeshProUGUI Rock_text;
    private float brickmethodcall_count;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void BrickAnimation()
    {
        animator.SetTrigger("Broke");
        Debug.Log("trigger");
        brickmethodcall_count++;

        if (brickmethodcall_count >= 3)
        {
            Debug.Log("congrats"); // here i want to play canvas of win 
            brickmethodcall_count = 0; 
        }
    }


    public void OnDestroy()
    {
      Rock.SetActive(false);
        Rock_text.text = null;
    }

    
}
    