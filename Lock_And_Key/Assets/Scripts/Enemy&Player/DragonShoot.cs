using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonShoot : MonoBehaviour
{
       public Animator anim;
       public float speed = 2f;
       public float stoppingDistance = 5f; // when enemy stops moving towards player
       public float retreatDistance = 3f; // when enemy moves away from approaching player
       private float timeBtwShots;
       public float startTimeBtwShots = 2;
       public GameObject projectile;

       private Rigidbody2D rb;
       private Transform player;
       private Vector2 PlayerVect;

       //public int EnemyLives = 30;
       private Renderer rend;
       //private GameHandler gameHandler;

       public float attackRange = 10;
       public bool isAttacking = false;
       private float scaleX;

       //Move Up and Down variables:
       private bool moveUpDown = false;
       private bool startBob = true;
       private bool bobUp = true;
       public float bobDistance = 3f;
       public float bobSpeed = 2f;
       Vector2 newBobPos;
       Vector2 newPosUp;
       Vector2 newPosDown;


       private Vector2 dragonPos;

       public Transform launchPoint;


       void Start () {
              Physics2D.queriesStartInColliders = false;
              scaleX = gameObject.transform.localScale.x;

              rb = GetComponent<Rigidbody2D> ();
              player = GameObject.FindGameObjectWithTag("Player").transform;
              PlayerVect = player.transform.position;

              timeBtwShots = startTimeBtwShots;

              rend = GetComponentInChildren<Renderer> ();

              dragonPos = transform.position;
              anim = GetComponentInChildren<Animator> ();

              //if (GameObject.FindWithTag ("GameHandler") != null) {
              // gameHander = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
              //}
       }

       void FixedUpdate () {
       rb.velocity = new Vector3(0f, 0f, 0f);
       if (player != null){
              float DistToPlayer = Vector3.Distance(transform.position, player.position);
              if (DistToPlayer <= attackRange) {
                     // approach player
                     //if (Vector2.Distance (transform.position, player.position) > stoppingDistance) {
                     if (Vector2.Distance (dragonPos, player.position) > stoppingDistance) {
                            Debug.Log("approaching");
                            transform.position = Vector2.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
                            if (isAttacking == false) {

                            }
                            moveUpDown = false;
                            dragonPos = transform.position;
                            startBob = true;
                            
                     }

                     // stop moving
                     //else if (Vector2.Distance (transform.position, player.position) < stoppingDistance && Vector2.Distance (transform.position, player.position) > retreatDistance) {
                     else if (Vector2.Distance (dragonPos, player.position) < stoppingDistance && Vector2.Distance (dragonPos, player.position) > retreatDistance) {
                            Debug.Log("stopped");
                            transform.position = this.transform.position;
                            //anim.SetBool("Walk", false);
                            moveUpDown = true;
                            //dragonPos = transform.position;

                     }

                     // retreat from player
                     //else if (Vector2.Distance (transform.position, player.position) < retreatDistance) {
                     else if (Vector2.Distance (dragonPos, player.position) < retreatDistance) {
                            Debug.Log("retreating");
                            transform.position = Vector2.MoveTowards (transform.position, player.position, -speed * Time.deltaTime);
                            //if (isAttacking == false) {
                                   //anim.SetBool("Walk", true);
                            //}
                            moveUpDown = false;
                            dragonPos = transform.position;
                            startBob =true;
                     }

                     //Flip enemy to face player direction. Wrong direction? Swap the * -1.
                     if (player.position.x > gameObject.transform.position.x){
                            gameObject.transform.localScale = new Vector2(scaleX * -1, gameObject.transform.localScale.y);
                    } else {
                             gameObject.transform.localScale = new Vector2(scaleX, gameObject.transform.localScale.y);
                     }

                     //Timer for shooting projectiles
                     if (timeBtwShots <= 0) {
                            isAttacking = true;
                            anim.SetTrigger("Attack");
                            Instantiate (projectile, launchPoint.position, Quaternion.identity);
                            timeBtwShots = startTimeBtwShots;
                     } else {
                            timeBtwShots -= Time.deltaTime;
                            isAttacking = false;
                     }
              } else {
                     dragonPos = transform.position;
              }
       }
       if (moveUpDown == true){
              if (startBob==true){
                     newPosUp = new Vector2(transform.position.x, transform.position.y + bobDistance);
                     newPosDown = new Vector2(transform.position.x, transform.position.y - bobDistance);
                     newBobPos = newPosUp;
                     startBob =false;
              }
              float distToUp = Vector2.Distance(transform.position, newPosUp);
              float distToDown = Vector2.Distance(transform.position, newPosDown);

              //if we are on the way up, and reach the top:
              if ((distToUp <= 0.2f)&&(bobUp)){
                     bobUp=false;
                     newBobPos = newPosDown;
                     }
              //if twe are on the way down, and reach the bottom:
              else if ((distToDown <= 0.2f)&&(!bobUp)){
                     bobUp=true;
                     newBobPos = newPosUp;
                     }

              transform.position = Vector2.MoveTowards (transform.position, newBobPos, bobSpeed * Time.deltaTime);

       }
       }

       void OnCollisionEnter2D(Collision2D collision){
              if (collision.gameObject.tag == "Player") {
                     gameObject.GetComponent<EnemyHealth>().TakeDamage(5);
              }
       }

       IEnumerator HitEnemy(){
              // color values are R, G, B, and alpha, each divided by 100
              rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
              if (gameObject.GetComponent<EnemyHealth>().health < 1){
                     //gameControllerObj.AddScore (5);
                     Destroy(gameObject);
              }
              else yield return new WaitForSeconds(0.5f);
              rend.material.color = Color.white;
       }

      //DISPLAY the range of enemy's attack when selected in the Editor
       void OnDrawGizmosSelected(){
              //Gizmos.DrawWireSphere(transform.position, attackRange);
              Gizmos.DrawWireSphere(transform.position, 9);
       }
}
