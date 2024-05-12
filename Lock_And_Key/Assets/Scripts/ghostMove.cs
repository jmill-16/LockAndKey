using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ghostMove : MonoBehaviour {

       public Rigidbody2D rb2D;
       public float speed = 4f;
       private Transform target;
       public int damage = 10;

       public int EnemyLives = 3;
       private GameHandler gameHandler;

       public float attackRange = 10;
       public bool isAttacking = false;
       private float scaleX;
       public GameObject renderer;

    //    public GameObject projectilePrefab;
    //    public Transform launchPoint;

    //    public float shootTime;
    //    public float shootCounter;

       void Start () {
            //   shootCounter = shootTime;
              rb2D = GetComponent<Rigidbody2D> ();
              scaleX = gameObject.transform.localScale.x;

              if (GameObject.FindGameObjectWithTag ("Player") != null) {
                     target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
              }

              if (GameObject.FindWithTag ("GameHandler") != null) {
                  gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
              }
       }

       void Update () {
              if (target != null) {
                float DistToPlayer = Vector3.Distance(transform.position, target.position);
                if ((target != null) && (DistToPlayer <= attackRange)){
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    //anim.SetBool("Walk", true);
                    //flip enemy to face player direction. Wrong direction? Swap the * -1.
                    if (target.position.x > gameObject.transform.position.x){
                                    renderer.transform.localScale = new Vector2(scaleX * -1, gameObject.transform.localScale.y);
                    } else {
                                    renderer.transform.localScale = new Vector2(scaleX, gameObject.transform.localScale.y);
                    }
                 }
              }

              
               //else { anim.SetBool("Walk", false);}
       }

        // public void OnTriggerEnter2D(Collider2D other) {
        //     if (other.gameObject.tag == "Player") {
        //         Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
        //         shootCounter = shootTime;
        //     }
        //     shootCounter -= Time.deltaTime;
        // }

    //    public void OnCollisionExit2D(Collision2D other){
    //           if (other.gameObject.tag == "Player") {
    //                  isAttacking = false;
    //                  //anim.SetBool("Attack", false);
    //           }
    //    }

       //DISPLAY the range of enemy's attack when selected in the Editor
       void OnDrawGizmosSelected(){
              Gizmos.DrawWireSphere(transform.position, attackRange);
       }
}