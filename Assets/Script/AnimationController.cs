using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public GameObject Rock;
    public TextMeshProUGUI Rock_text;
 
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void BrickAnimation()
    {
        animator.SetTrigger("Broke");
        Debug.Log("trigger");
    }
   

    public void OnDestroy()
    {
      Rock.SetActive(false);
        Rock_text.text = null;
    }

    public void OnbrickDestroySound()
    {
        AudioManager.inst.PlaySound(SoundName.Stone_Broke);

    }



}
    