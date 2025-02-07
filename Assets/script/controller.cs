using UnityEngine;

public class controller : MonoBehaviour
{
    float horizontal;
    float vertical;
    public Transform orien;
    public Rigidbody body;
    public float moveSpeed = 5f;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        Vector3 movementDirection = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movementDirection, Space.World);
    }
}
