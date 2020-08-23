using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour
{

    void Update() {
        this.transform.eulerAngles = new Vector3(
            this.transform.eulerAngles.x,
            this.transform.eulerAngles.y,
            0
        );
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.GetComponent<Conveyor>()) {
            GameObject conveyorObj = other.gameObject;
            Conveyor conveyor = conveyorObj.GetComponent<Conveyor>();
            this.transform.position += conveyor.transform.right * conveyor.speed * Time.deltaTime;
        }
    }
}
