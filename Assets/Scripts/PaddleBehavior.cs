using UnityEngine;
using System.Collections;

public class PaddleBehavior : MonoBehaviour
{

    public bool AutoPlay = false;

    private BallBehavior ball;

	// Use this for initialization
	void Start ()
	{
	    ball = GameObject.FindObjectOfType<BallBehavior>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (AutoPlay)
	    {
	        MoveByBal();
	    }
	    else
	    {
	        MoveByMouse();
	    }
	}

    void MoveByBal()
    {
        Vector3 paddlePos = new Vector3(0, this.transform.position.y, 0f);
        Vector3 ballPOsition = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPOsition.x, 0.5f, 15.5f);

        this.transform.position = paddlePos;
    }

    void MoveByMouse()
    {
        Vector3 paddlePos = new Vector3(0, this.transform.position.y, 0f);

        float mousePositionInBlocks = (Input.mousePosition.x / Screen.width * 16);
        paddlePos.x = Mathf.Clamp(mousePositionInBlocks, 0.5f, 15.5f);

        this.transform.position = paddlePos;
    }

}
