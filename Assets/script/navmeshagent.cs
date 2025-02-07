using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class navmeshagent : MonoBehaviour
{
    public float health = 300f;
    private Transform target;
    public NavMeshAgent agent;
    public float totalDistance;
    public enum State { Idle, Speed }
    public State currentState = State.Idle;
    public float walkSpeed = 4f;
    public float fastSpeed = 8f;
    private bool speedBoosted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Finish").transform;

        if (target != null)
        {
            agent.SetDestination(target.position);
            totalDistance = GetPathLength(agent);
        }

        agent.speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        float remainingDistance = GetPathLength(agent);

        if (remainingDistance <= totalDistance / 3 && currentState == State.Idle)
        {
            agent.speed = fastSpeed;
            speedBoosted = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Finish"))
        {
            SceneManager.LoadScene("Lost");
        }
    }
    float GetPathLength(NavMeshAgent agent)
    {
        NavMeshPath path = new NavMeshPath();
        if(!agent.CalculatePath(agent.destination, path))
            return Mathf.Infinity;

        float length = 0;
        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            length += Vector3.Distance(path.corners[i], path.corners[i + 1]);
        }
        return length;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }
}
