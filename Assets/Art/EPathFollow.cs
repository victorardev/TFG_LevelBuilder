using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPathFollow : MonoBehaviour
{
    private int currentIndex = 0;
    float t = 0.0f;
    public float speed;
    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //t += Time.deltaTime;
        //transform.position = Vector3.Lerp(transform.position, 
        //    GameManager.pointList[currentIndex], t * Time.deltaTime * speed);

        Vector3 desiredVelocity = GameManager.pointList[currentIndex] - transform.position;
        desiredVelocity.Normalize();
        desiredVelocity *= 3.0f;
        body.velocity = desiredVelocity;

        if (Vector3.Distance(transform.position, GameManager.pointList[currentIndex]) < 1.0f)
        {
            currentIndex++;
        }
        if(currentIndex >= GameManager.pointList.ToArray().Length)
        {
            Destroy(this.gameObject);
        }
    }
}
