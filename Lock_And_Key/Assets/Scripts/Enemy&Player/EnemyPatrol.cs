using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    private bool FaceLeft = true; // determine which way player is facing.
    AudioSource audioSourse;
    private Vector3 hMove;

    // private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
        audioSourse = GetComponent<AudioSource>();
        // anim.SetBool("isRunning", true);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(Vector3.Distance(transform.position, currentPoint.position));
        Vector3 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
            Debug.Log("B");
            // Debug.Log(Vector3.Distance(transform.position, currentPoint.position));
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            Debug.Log("A");
            rb.velocity = new Vector2(-speed, 0);
            audioSourse.Play();
        }

        if(Vector3.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            Debug.Log("going to A");
            currentPoint = pointA.transform;
            if(!FaceLeft) {
                flip();
            }
        }
        if(Vector3.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            Debug.Log("going to B");
            currentPoint = pointB.transform;
            if(FaceLeft) {
                flip();
            }
        }
    }

    private void flip()
    {
        if(!audioSourse.isPlaying)
        {
                audioSourse.Play();
        }
        FaceLeft = !FaceLeft;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
