using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int cactus = 3;
    public int iron = 5;
    public int juice = 4;
    public int cactusJuicers = 3;
    public int conveyors = 3;
    public int miners = 2;
    public int collectors = 1;
    
    public GameObject slotPrefab;

    public Sprite[] sprites;
    public Sprite[] emptySprites;
    
    void Start()
    {
        createSlots();
    }

    void createSlots() {
        int id = 0;
        for(float row = 0.62f; row >= -0.64f; row-=0.42f) {
            for(float col = -0.62f; col <= 0.64f; col+=0.42f) {
                GameObject slot = Instantiate(slotPrefab, new Vector3(col, row, -3f), Quaternion.identity);
                Slot slotScript = slot.GetComponent<Slot>();
                if(id < sprites.Length) {
                    slotScript.full = sprites[id];
                    slotScript.empty = emptySprites[id];
                }
                slotScript.item = sprites[id].name;
                slotScript.id = id;

                slot.transform.SetParent(this.transform, false);
                id++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateItems();
    }

    void updateItems() {
        int[] counts = {
            cactus, iron, juice, 0, 
            0, 0, 0, 0, 
            0, 0, 0, 0, 
            cactusJuicers, conveyors, miners, collectors
        };
        Slot[] slots = FindObjectsOfType<Slot>();
        for(int i = 0; i < slots.Length; i++) {
            slots[i].count = counts[slots[i].id];
        }
    }
}
