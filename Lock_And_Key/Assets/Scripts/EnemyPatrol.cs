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
    void Update()
    {

        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
            audioSourse.Play();
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
            if(!FaceLeft) {
                flip();
            }
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
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
