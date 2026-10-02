using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 8;
    [SerializeField] float gravity = 2;
    [SerializeField] float rotSpeed = 200;

    Rigidbody2D rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Jump();
        }
        BirdRotate();
    }

    void Jump()
    {
        rb.gravityScale = gravity;
        rb.velocity = new Vector2(0, jumpSpeed);
        FindAnyObjectByType<TubeSpawner>().StartSpawning();
    }

    void BirdRotate()
    {
        if (rb.velocity.y > 0.5f)
            transform.Rotate(0, 0, rotSpeed * Time.deltaTime);

        if (rb.velocity.y < -0.5f)
            transform.Rotate(0, 0, -rotSpeed * Time.deltaTime);

        float rz = transform.eulerAngles.z;
        if (rz > 60 && rz < 180)
            transform.rotation = Quaternion.Euler(0, 0, 60);
        if(rz < 300 && rz > 180)
            transform.rotation = Quaternion.Euler(0, 0, 300);

    }
}
