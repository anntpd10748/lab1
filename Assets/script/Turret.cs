using UnityEngine;

public class AoeTurret : MonoBehaviour
{
    public float range = 5f;       
    public float damagePerSecond = 20f;

    void Update()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, range);
        foreach (Collider enemy in enemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<navmeshagent>()?.TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
    }

}
