using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    public int worldSize = 50;

    void Start() {
        DontDestroyOnLoad(this);    
    }

    public void setWorldSize(int size) {
        worldSize = size;
    }
}
