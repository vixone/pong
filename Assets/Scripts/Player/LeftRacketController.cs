using UnityEngine;
using System.Collections;

public class LeftRacketController : MonoBehaviour {

    public float speed = 80;
    public string axis = "Vertical2";

    public int Score;

    private void Start()
    {
        Score = 0;
    }
    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw(axis);

        //we only need movement on the y axis, x axis will always be 0
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }
}
