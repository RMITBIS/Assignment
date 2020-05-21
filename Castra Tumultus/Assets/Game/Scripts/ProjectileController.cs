using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject player;
    public float damage;
    
    private void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().onDamage(damage);
        }
    }
}
