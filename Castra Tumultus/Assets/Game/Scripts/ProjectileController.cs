using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject player;
    private void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject, 1f);
    }
}