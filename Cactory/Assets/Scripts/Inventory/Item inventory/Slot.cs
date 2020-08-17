using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slot : MonoBehaviour 
{
    public int count;
    public int id = 0;

    public string item;

    public Sprite empty;
    public Sprite full;
    
    public GameObject countTextObj;

    public SpriteRenderer renderer;
    private TextMeshPro countText;
    
    void Awake() {
        countText = countTextObj.GetComponent<TextMeshPro>();      
    }

    void Update() {
        if(count > 0) {
            renderer.sprite = full;
        } else {
            renderer.sprite = empty;
        }
        countText.text = count.ToString();
    }
}
