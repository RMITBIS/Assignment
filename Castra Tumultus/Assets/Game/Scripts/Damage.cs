using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private Health _health;
    //Detect collisions between the GameObjects with Colliders attached
    private void Start()
    {
        _health = GetComponent<Health>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Enemy")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console

            //Destroy(collision.gameObject);
            // Destroy(collision.gameObject);
            gameObject.GetComponent<Health>().setCurrentDamage(5);
            Debug.Log("Do something here");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "MyGameObjectTag")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }
}