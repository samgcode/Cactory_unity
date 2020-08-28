using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManager : MonoBehaviour
{
    public void newGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void startGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void loadGame() {

    }

    public void controlls() {

    }

    public void tutorial() {

    }
}
