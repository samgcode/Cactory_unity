using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSizeController : MonoBehaviour
{
    public Settings settings;

    void Start()
    {
        settings = FindObjectOfType<Settings>();
    }

    public void setMapSize(int size) {
        settings.setWorldSize(size);
    }
}
