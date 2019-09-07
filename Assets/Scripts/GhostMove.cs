using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public Transform[] waypoints;
    int cur = 0;
    private bool reachedWayPoint = false;

    public float speed = 0.3f;

    void FixedUpdate()
    {
        // Waypoint not reached yet? then move closer
        if (!reachedWayPoint)
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Waypoint reached, select next one
        else
        {
            reachedWayPoint = false;
            cur = (cur + 1) % waypoints.Length;
            Debug.Log(cur);
        }

        // Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "blinky_path" + cur)
        {
            Debug.LogError("Waypoint reached");
            reachedWayPoint = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D co)
    {
        if (co.transform.tag == "Player")
            Destroy(co.gameObject);
    }
}
