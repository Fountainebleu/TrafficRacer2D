using UnityEngine;

public class Car_Movement : MonoBehaviour
{
    public Transform transform;
    public float speed = 5f;

    void Start()
    {
        transform = GetComponent<Transform>();
    }
    
    void Update()
    {
        transform.position -= new Vector3(transform.position.x, speed * Time.deltaTime, transform.position.z);
        //if(transform.position.y <= -6)
        //{
        //    Destroy(gameObject);
        //}
    }
}
