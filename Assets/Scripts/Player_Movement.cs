using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Transform transform;
    public float speed = 5f;
    public float rotationSpeed = 5f;
    //public Score_Manager scoreValue;
    //public GameObject gameOverPanel;
    bool isMovingLeft = false;
    bool isMovingRight = false;
    //public AudioSource collisionAudio;
    //public AudioSource collectAudio;
    //public Ads_Manager ads;

    void Start()
    {
        //gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }
    
    void Update()
    {
        Movement();
        Clamp();
        
        if(isMovingLeft || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if(isMovingRight || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }

    void Movement()
    {

        if (transform.rotation.z != 90)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 90), 10f * Time.deltaTime);
        }
    }

    void MoveLeft()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 137), rotationSpeed * Time.deltaTime);
    }

    void MoveRight()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 43), rotationSpeed * Time.deltaTime);
    }

    public void MovingLeft(bool i)
    {
        isMovingLeft = i;
    }

    public void MovingRight(bool i)
    {
        isMovingRight = i;
    }

    void Clamp()
    {
        // Clamping Player to Screen
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -3.3f, 3.2f);
        transform.position = pos;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cars")
        {
            Time.timeScale = 0;
            //gameOverPanel.SetActive(true);
            //collisionAudio.Play();
            //ads.PlayAd();
        }
        
        if (collision.gameObject.tag == "Coin")
        {
            //scoreValue.score += 10;
            Destroy(collision.gameObject);
            //collectAudio.Play();
        }

    }
}
