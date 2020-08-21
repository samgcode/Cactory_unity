using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Crafting : MonoBehaviour
{
    public PlayerManager player;

    public GameObject[] recipes;

    public TextMeshPro resultText;
    public TextMeshPro resultCountText;
    public TextMeshPro[] ingredientTexts;
    public TextMeshPro[] countTexts;

    void Start()
    {
        int id = 0;
        for(float row = 0.62f; row >= -0.64; row-=0.42f) {
            for(float col = -0.62f; col <= 0f; col+=0.42f) {
                GameObject recipe = Instantiate(recipes[id], new Vector3(col, row, -3f), Quaternion.identity);
                recipe.transform.SetParent(this.transform, false);
                id++;
            }
        }
    }

    public void updateText(Recipe recipe) {
        resultText.text = recipe.result;
        resultCountText.text = "X " + recipe.resultCount.ToString();
        for(int i = 0; i < ingredientTexts.Length; i++) {
            if(recipe.ingredientCounts[i] != 0) {
                ingredientTexts[i].text = recipe.ingredients[i];
                countTexts[i].text = "X " + recipe.ingredientCounts[i].ToString();         
            }
        }
    }

    public void resetText() {
        resultText.text = "";
        resultCountText.text = "";
        for(int i = 0; i < ingredientTexts.Length; i++) {
            ingredientTexts[i].text = "";
            countTexts[i].text = "";
        }
    }

    public void craft(Recipe recipe) {
        if(canCraft(recipe)) {
            player.addItem(recipe.result, recipe.resultCount);
            for(int i = 0; i < recipe.ingredients.Length; i++) {
                player.removeItem(recipe.ingredients[i], recipe.ingredientCounts[i]);
            }
        }
    }

    bool canCraft(Recipe recipe) {
        for(int i = 0; i < recipe.ingredients.Length; i++) {
            if(player.checkItem(recipe.ingredients[i], recipe.ingredientCounts[i]) == false) {
                return false;
            }
        }
        return true;
    }
}
