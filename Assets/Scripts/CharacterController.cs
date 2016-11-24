using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    public float maxSpeed = 10f;
    bool grounded = false;
    bool isThereHole = false;
    public Transform hole;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public int jumpForce = 700;
    Vector2 startPos;

    // Use this for initialization
    void Start ()
    {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        float move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (isThereHole)
        {
            transform.position = startPos;
            isThereHole = false;
        }
	}

    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Hole")
        {
            isThereHole = true;
        }
    }
}
