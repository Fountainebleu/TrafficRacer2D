using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Transform transform;
    public float speed = 5f;
    public float rotationSpeed = 5f;
    public Score_Manager scoreValue;
    public GameObject gameOverPanel;
    bool isMovingLeft = false;
    bool isMovingRight = false;

    void Start()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        
    }
    
    void Update()
    {
        Movement();
        Clamp();
        
        if(isMovingLeft || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if(isMovingRight || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
    }

    void Movement()
    {

        if (transform.rotation.z != 90)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 10f * Time.deltaTime);
        }
    }

    void MoveLeft()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 49), rotationSpeed * Time.deltaTime);
    }

    void MoveRight()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -49), rotationSpeed * Time.deltaTime);
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
        if(collision.gameObject.tag == "Car")
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            AudioManager.Instance.PlayCrashSound();
            AudioManager.Instance.StopMusic();
        }
        
        if (collision.gameObject.tag == "Coin")
        {
            scoreValue.score += 10;
            Destroy(collision.gameObject);
            AudioManager.Instance.PlayCoinSound();
        }

    }
}
