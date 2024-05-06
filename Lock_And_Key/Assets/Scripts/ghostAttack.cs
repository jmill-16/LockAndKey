using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostAttack : MonoBehaviour
{
    public GameObject ghostBall;
    public Transform ghostBallPos;
    private float burstTimer = 0.0f;
    public int shotsPerBurst = 3;
    private GameObject player;
    public bool shooting = false;
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        if(player != null) {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < 8) {
                if (!shooting) {
                    burstTimer += Time.deltaTime;
                }            
                if (burstTimer >= 1) {
                    StartCoroutine(DelayBetweenBursts());
                    burstTimer = 0;
                    shooting = true;
                }
            }
        }
        
    }

    void shoot() {
        Instantiate(ghostBall, ghostBallPos.position, Quaternion.identity);
    }

    IEnumerator DelayBetweenBursts() {
        for (int i = 0; i < shotsPerBurst; i++) {
            shoot();
            yield return new WaitForSeconds(0.33f);
        }
        yield return new WaitForSeconds(1.0f);
        shooting = false;
    }

}