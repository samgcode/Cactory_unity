using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    public Transform itemSpawnpoint;
    public GameObject itemPrefab;
    public float powerNeeded = 5f;
    public float spawnSpeed = 3f;
    public PlayerService playerService;

    Animator animator;
    PowerNode node;
    bool hasNode = false;
    bool hasPower = false;

    bool invokeCanceled = true;

    void Start()
    {
        playerService = FindObjectOfType<PlayerService>();
        findNode();
        animator = GetComponent<Animator>();

    }

    void Update() {
        if(hasNode) {
            if(node.power >= powerNeeded) {
                hasPower = true;
                if(invokeCanceled) {
                    InvokeRepeating("spawnItem", 1f, spawnSpeed);
                    invokeCanceled = false;
                }
            } else {
                hasPower = false;
                CancelInvoke();
                invokeCanceled = true;
            }

            animator.SetBool("animating", hasPower);
        }
    }

    void spawnItem() {
        if(hasNode) {
            if(hasPower) {
                node.power -= powerNeeded;
                Instantiate(itemPrefab, itemSpawnpoint.position, Quaternion.identity);
            }
        }
    }

    public void findNode() {
        Debug.Log("finding node...");
        node = playerService.getNodeInRange(transform.parent.GetComponent<Tile>());
        if(node) {
            hasNode = true;
            Debug.Log("node found");
        }
    }
}
