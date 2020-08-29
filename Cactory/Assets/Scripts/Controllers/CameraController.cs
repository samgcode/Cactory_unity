using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;

    public GenerateMap mapGenerator;

    public Transform inventory;

    public Camera camera;

    public int maxX = 0;
    public int maxY = 0;
    public int minX = 0;
    public int minY = 0;

    public float zoomSpeed;

    void Awake() {
        int halfWorldSize = mapGenerator.worldSize / 2;
        maxX = halfWorldSize - 10;
        maxY = halfWorldSize - 6;

        minX = -1 * (halfWorldSize - 9);
        minY = -1 * (halfWorldSize - 5);
    } 

    void FixedUpdate()
    {
        float xPos = this.transform.position.x;
        float yPos = this.transform.position.y;
        float zPos = this.transform.position.z;

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

        if(Input.GetAxis("Mouse ScrollWheel") > 0f) {
            if(camera.orthographicSize > 2) {
                camera.orthographicSize -= zoomSpeed;
            }
        } else if(Input.GetAxis("Mouse ScrollWheel") < 0f) {
            if(camera.orthographicSize < 10) {
                camera.orthographicSize += zoomSpeed;
            }
        }

        float width = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
        inventory.localScale = new Vector3(width / 17f, width / 17f, inventory.localScale.z);

        this.transform.position = new Vector3(xPos, yPos, zPos);
    }
}