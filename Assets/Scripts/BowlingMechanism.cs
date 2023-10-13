using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class BowlingMechanism : MonoBehaviour
{
    [SerializeField] private float bowlInterval = 5f;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform releasePoint;
    [SerializeField] private float minSpeed = 10f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private float minSwing = -5f;
    [SerializeField] private float maxSwing = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= bowlInterval)
        {
            BowlBall();
            timer = 0f;
        }
    }


    public void DestroyBall(GameObject ball)
    {
        Destroy(ball, 5f); // Destroys the ball 5 seconds after being bowled.
    }



    public void BowlBall()
    {
        GameObject ball = Instantiate(ballPrefab, releasePoint.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        float speed = Random.Range(minSpeed, maxSpeed);
        float swing = Random.Range(minSwing, maxSwing);

        Vector3 force = new Vector3(swing, 0, speed);
        rb.AddForce(force, ForceMode.VelocityChange);
    }

}
