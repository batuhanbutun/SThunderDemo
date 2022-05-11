using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 startScale;
    [SerializeField] private Animator myAnim;
    private float standTime=0;
    void Start()
    {

    }

   
    void Update()
    {
        if (standTime > 0)
            standTime -= Time.deltaTime;
    }

    public void Crouch()
    {
        if(standTime <= 0f)
        {
            myAnim.SetTrigger("dodge");
            standTime = 1f;
        }
    }
}
