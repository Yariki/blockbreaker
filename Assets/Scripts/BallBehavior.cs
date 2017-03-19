using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour
{

    private PaddleBehavior Paddle;

    private bool hasStarted = false;
    private Vector3 paddleToBallVector3;

	// Use this for initialization
	void Start ()
	{
	    Paddle = GameObject.FindObjectOfType<PaddleBehavior>();
	    paddleToBallVector3 = this.transform.position - Paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!hasStarted)
	    {
            // lock the ball relative to the paddle
            this.transform.position = Paddle.transform.position + paddleToBallVector3;

            // press left nutton for launch
            if (Input.GetMouseButtonDown(0))
            {
                this.rigidbody2D.velocity = new Vector2(2f, 15f);
                hasStarted = true;
            }
	    }
	    
	}

    void OnCollisionEnter2D(Collision2D collision2)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f),Random.Range(0f,0.2f));

        if (hasStarted)
        {
            audio.Play();
            rigidbody2D.velocity += tweak;
        }
    }
}
