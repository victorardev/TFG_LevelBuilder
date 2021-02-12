using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    public int live = 100;
    public GameObject dieParticle;
    private void Update()
    {
        if(live <= 0)
        {
            Destroy(gameObject);
            //PARTICLE:
            Instantiate(dieParticle, transform.position, dieParticle.transform.rotation);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            live -= 10;
        }
    }
}
