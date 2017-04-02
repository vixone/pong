using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {


    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                   float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        //we subtract the racketPos.y from the ballPos.y to have a relative position.
        return (ballPos.y - racketPos.y) / racketHeight;
    }
    public float speed = 60;
    private Vector2 startPosition;
    private Rigidbody2D ballBodyRef;

    RightRacketController rightPlayerScore;
    LeftRacketController leftPlayerScore;






    void Start()
    {

        GameObject rightPlayer = GameObject.Find("RacketRight");
        rightPlayerScore = rightPlayer.GetComponent<RightRacketController>();

        GameObject leftPlayer = GameObject.Find("RacketLeft");
        leftPlayerScore = leftPlayer.GetComponent<LeftRacketController>();
        
        ballBodyRef = GetComponent<Rigidbody2D>();

        // Initial Velocity
        ballBodyRef.velocity = Vector2.right * speed;

        // Initial Position
        startPosition = transform.position;
    
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        //Hit The Left Racket?
        if (col.gameObject.name == "RacketLeft")
        {
            // Calculate the hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make Lenght=1 via.normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.name == "LeftWall" || col.gameObject.name == "RightWall")
        {
            transform.position = startPosition;

            //change directon of ball according to win
            if (col.gameObject.name == "LeftWall") //right player wins
            {
                ballBodyRef.velocity = Vector2.left * speed;
                // GameObject.Find("RacketRight").GetComponent<RightRacketController>().Score++;
                rightPlayerScore.Score += 1;
            }
            else if (col.gameObject.name == "RightWall") //left player wins
            {
                ballBodyRef.velocity = Vector2.right * speed;
                leftPlayerScore.Score += 1;
            }
        }

    } 

  

   


}
