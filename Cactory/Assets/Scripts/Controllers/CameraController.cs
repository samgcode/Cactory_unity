using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;

    public SceneManager sceneManager;

    public Camera camera;

    public int maxX = 0;
    public int maxY = 0;
    public int minX = 0;
    public int minY = 0;

    public float zoomSpeed;

    void Awake() {
        int halfWorldSize = sceneManager.worldSize / 2;
        maxX = halfWorldSize - 10;
        maxY = halfWorldSize - 6;

        minX = -1 * (halfWorldSize - 9);
        minY = -1 * (halfWorldSize - 5);
    } 

    void FixedUpdate()
    {
        float xPos = this.transform.position.x;
        float yPos = this.transform.position.y;

        if(Input.GetKey(KeyCode.W)) {
            if(yPos + speed < maxY) {
                yPos += speed;
            }
        }  
        if(Input.GetKey(KeyCode.S)) {
            if(yPos - speed > minY) {
                yPos -= speed;
            }
        } 
        if(Input.GetKey(KeyCode.D)) {
            if(xPos + speed < maxX) {
                xPos += speed;
            }
        }
        if(Input.GetKey(KeyCode.A)) {
            if(xPos - speed > minX) {
                xPos -= speed;
            }
        }

        this.transform.position = new Vector3(xPos, yPos, this.transform.position.z);

        if(Input.GetAxis("Mouse ScrollWheel") > 0f) {
            if(camera.orthographicSize > 2) {
                camera.orthographicSize -= zoomSpeed;
            }
        } else if(Input.GetAxis("Mouse ScrollWheel") < 0f) {
            if(camera.orthographicSize < 10) {
                camera.orthographicSize += zoomSpeed;
            }
        }
    }
}