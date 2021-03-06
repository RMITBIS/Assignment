﻿using System;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public GameObject projectile;
    public int projectileSpeed;
    public float projectileCooldown;
    public float despawnTime;
    
    private Rigidbody _body;
    private float cooldown;

    //added to lock controls once dead
    private Health _health;

    void Start()
    {
        _health = GetComponent<Health>();
        _body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.mousePosition.x - Screen.width / 2f;
        float v = Input.mousePosition.y - Screen.height / 2f;

        float yRotation = (float) Math.Atan2(h, v);
        Quaternion modelRot = Quaternion.Euler(0, yRotation * 60, 0);

        //transform wrapped in an if statement as to not allow movement if helth is 0
        if (_health.getCurrentHealth() > 0)
        {
            transform.rotation = modelRot;
        }

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else if (cooldown < 0)
        {
            cooldown = 0;
        }

        //extra conditon added for checking health is greater than zero befor allowing movemnet
        if (Input.GetMouseButtonDown(0) && cooldown <= 0 && _health.getCurrentHealth() > 0)
        {
            cooldown += projectileCooldown;
            Vector3 position = _body.position;
            Vector3 bulletPos = new Vector3(position.x, 0.35f, position.z);
            Quaternion bulletRot = Quaternion.Euler(-90, yRotation * 60f, 0);

            GameObject obj = Instantiate(projectile, bulletPos, bulletRot);
            obj.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
            Destroy(obj, despawnTime);
        }
    }
}
