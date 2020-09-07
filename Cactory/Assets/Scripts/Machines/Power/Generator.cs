using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Animator animator;
    public PowerNode powerNode;

    public bool generating = false;

    void Start()
    {
        powerNode = GetComponent<PowerNode>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(generating) {
            powerNode.power += 0.18f;
        }
    }

    public void Generate() {
        // generating = true;
        animator.Play("generator", 0, 0.0f);
        powerNode.power += 15;
        // Invoke("stopGenerating", 2f);
    }

    public void stopGenerating() {
        generating = false;
    }
}
