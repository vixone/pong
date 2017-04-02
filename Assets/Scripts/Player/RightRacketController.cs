using UnityEngine;
using System.Collections;

public class RightRacketController : MonoBehaviour
{

    //public makes it show up and can be modified in inspector
    public float speed = 30;
    public string axis = "Vertical";

    public int Score;

    private void Start()
    {
        Score = 0;
    }

    private void Update()
    {
        Debug.Log(Score);
    } 
    //run phisics stuff in FixedUpdate()
    private void FixedUpdate()
    {
       
        //check the vertical input axis: up = 1, down = -1; none = 0;
        float v = Input.GetAxisRaw(axis);

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;

    }
}
