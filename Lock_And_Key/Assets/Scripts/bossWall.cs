using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class bossWall : MonoBehaviour
{
    public GameObject player;
    public GameObject bWall;
    public bool visible;
    public TilemapRenderer tr;
    public CompositeCollider2D compCol;
    public Respawn rsp;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bWall = GameObject.FindGameObjectWithTag("bossWall");
        rsp = player.GetComponent<Respawn>();
        visible = false;
        tr = GetComponent<TilemapRenderer>();
        compCol = GetComponent<CompositeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerHealth>().health <= 0) {
            visible = false;
            compCol.isTrigger = true;
        }
        if(player.transform.position.y < rsp.threshold){
            visible = false;
            compCol.isTrigger = true;
        }
        if(visible == true) {
            tr.enabled = true;
        } else {
            tr.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            if(player.transform.position.x > transform.position.x + 28f) {
                Debug.Log("Player transform = " + player.transform.position.x +"|||| Wall transform = " + transform.position.x + 28f);
                visible = true;
                compCol.isTrigger = false;
            }
        }
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(1.5f);
    }
}
