using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float power = 0f;
    public Animator animator;

    public bool generating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(generating) {
            power += 0.1f;
        }
    }

    public void Generate() {
        generating = true;
        animator.Play("generator", 0, 0.0f);
        Invoke("stopGenerating", 2f);
    }

    public void stopGenerating() {
        generating = false;
    }
}
