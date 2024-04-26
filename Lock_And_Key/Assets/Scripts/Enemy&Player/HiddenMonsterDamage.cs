using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenMonsterDamage : MonoBehaviour
{
    //public Animator anim;
    public float speed;
    private GameObject player;

    //public bool chase = false;

    public Transform startingPoint;

    public GameHandler gamehandler;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        gamehandler = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
        
    }
    void Update () {
        //if (gamehandler.viewPurpleOn) {
            Chase();
        //} else 
        //{
        //    ReturnStartPoint();
        //}
        Flip();
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }
    

    
}
