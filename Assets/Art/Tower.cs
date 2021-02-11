using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    enum States { hold, done}
    States state = States.hold;
    float distance = 1.0f;
    float actualDistance = 0.0f;
    GameObject mainObjectToShoot = null;
    public GameObject bala;
    float timer = 0.2f;

    public void Start()
    {
        Vector3 toObjectVector = transform.position - Camera.main.transform.position;
        Vector3 linearDistanceVector = Vector3.Project(toObjectVector, Camera.main.transform.forward);
        actualDistance = linearDistanceVector.magnitude;
    }

    public void Update()
    {
        if(PathCreate.pathReady)
        {
            switch (state)
            {
                case States.hold:
                    Vector3 mousePosition = Input.mousePosition;
                    mousePosition.z = actualDistance;
                    transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
                    transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
                    if (Input.GetMouseButtonDown(0))
                    {
                        state = States.done;
                    }
                    break;
                case States.done:
                    //Functionality tower: 
                    Vector3 look = mainObjectToShoot.transform.position - transform.position;
                    transform.rotation = Quaternion.LookRotation(look);
                    timer -= Time.deltaTime;
                    if(timer <= 0.0f)
                    {
                        GameObject b = Instantiate(bala, transform.position, transform.rotation);
                        b.GetComponent<Bala>().initForce = look;
                        timer = 1.2f;
                    }
               
                    break;
            }
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            mainObjectToShoot = other.gameObject;
        }
    }
}
