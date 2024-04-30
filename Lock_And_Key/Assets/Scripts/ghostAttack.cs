using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostAttack : MonoBehaviour
{
    public GameObject ghostBall;
    public Transform ghostBallPos;
    private float timer;
    private GameObject player;
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);
        if (distance < 8) {
            timer += Time.deltaTime;
            if(timer > 1) {
            timer = 0;
            shoot();
        }
        }

        
    }

    void shoot() {
        Instantiate(ghostBall, ghostBallPos.position, Quaternion.identity);
    }
}