using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;

    public GameObject singleChunk;

    public Vector4 centerArea;

    public Transform camera;

    int centerOffset = 18;

    int ringNumber = 1;

    void Awake() {
        camera = this.transform;
        centerArea = new Vector4(camera.position.x, camera.position.y, camera.position.x, camera.position.y);   
    }

    void Update() {
        Vector3 position = camera.position;

        if( 
        position.y > centerArea.w || //up
        position.y < centerArea.y || //down
        position.x > centerArea.z || //right
        position.x < centerArea.x ) { //left
            centerArea.w += centerOffset;
            centerArea.y -= centerOffset;
            centerArea.z += centerOffset;
            centerArea.x -= centerOffset;
            Debug.Log("exited bounds");
            generate();
        }
    }

    void FixedUpdate()
    {
        float xPos = camera.position.x;
        float yPos = camera.position.y;

        if(Input.GetKey(KeyCode.W)) {
            yPos += speed;
        } else if(Input.GetKey(KeyCode.S)) {
            yPos -= speed;
        } else if(Input.GetKey(KeyCode.D)) {
            xPos += speed;
        } else if(Input.GetKey(KeyCode.A)) {
            xPos -= speed;
        }

        this.transform.position = new Vector3(xPos, yPos, camera.position.z);
    }

    void generate() {
        float rows = (centerArea.z - centerArea.x) / 18;
        float cols = (centerArea.w - centerArea.y) / 18;
        for(float y = centerArea.y; y < centerArea.w + 18; y+=18) {
            if(y == centerArea.y) {
                for(float x = centerArea.x; x <= centerArea.z; x+=18) {
                    Instantiate(singleChunk, new Vector3(x, y, 0), Quaternion.identity);
                }
            } else if(y == centerArea.w) {
                for(float x = centerArea.x; x < centerArea.z+18; x+=18) {
                    Instantiate(singleChunk, new Vector3(x, y, 0), Quaternion.identity);
                }
            } else {
                Instantiate(singleChunk, new Vector3(centerArea.x, y, 0), Quaternion.identity);
                Instantiate(singleChunk, new Vector3(centerArea.z, y, 0), Quaternion.identity);
            }
        }
    }
}