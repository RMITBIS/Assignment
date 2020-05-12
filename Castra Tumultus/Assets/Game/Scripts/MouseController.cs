using System;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public GameObject projectile;
    public int projectileSpeed;
    public float projectileCooldown;
    public float despawnTime;

    private Rigidbody _body;
    private float cooldown;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.mousePosition.x - Screen.width / 2f;
        float v = Input.mousePosition.y - Screen.height / 2f;

        float yRotation = (float) Math.Atan2(h, v);
        Quaternion modelRot = Quaternion.Euler(0, yRotation * 60f, 0);

        transform.rotation = modelRot;

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else if (cooldown < 0)
        {
            cooldown = 0;
        }

        if (Input.GetMouseButtonDown(0) && cooldown <= 0)
        {
            cooldown += projectileCooldown;
            Vector3 position = _body.position;
            Vector3 bulletPos = new Vector3(position.x, 0.35f, position.z);
            Quaternion bulletRot = Quaternion.Euler(-90, yRotation * 60f, 0);

            GameObject ah = Instantiate(projectile, bulletPos, bulletRot);
            ah.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
            Destroy(ah, despawnTime);
        }
    }
}