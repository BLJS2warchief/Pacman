using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacmanMove : MonoBehaviour
{
    public float speed = 1f;
    Vector2 dest = Vector2.zero;
    private float moveX;
    private float moveY;

    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        

        if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up / 3))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, moveY * speed);
            GetComponent<Animator>().SetFloat("DirX", 0f);
            GetComponent<Animator>().SetFloat("DirY", 0.2f);
            dest = (Vector2)transform.position + Vector2.up / 3;
        }
        if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right / 3))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, 0);
            GetComponent<Animator>().SetFloat("DirX", 0.2f);
            GetComponent<Animator>().SetFloat("DirY", 0f);
            dest = (Vector2)transform.position + Vector2.right / 3;
        }
        if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up / 3))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, moveY * speed);
            GetComponent<Animator>().SetFloat("DirX", 0f);
            GetComponent<Animator>().SetFloat("DirY", -0.2f);
            dest = (Vector2)transform.position - Vector2.up / 3;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right / 3))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, 0);
            GetComponent<Animator>().SetFloat("DirX", -0.2f);
            GetComponent<Animator>().SetFloat("DirY", 0f);
            dest = (Vector2)transform.position - Vector2.right / 3;
        }
        
    }
    bool valid(Vector2 dir)
    {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        //Debug.Log(dir);
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.left);
        //Debug.Log(hit.collider);
        return (hit.collider == GetComponent<Collider2D>());
    }
}
