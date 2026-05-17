using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    public static Player_Controller instance;

    [SerializeField] private float mouse_sensitivity;
    [SerializeField] private float bounce_power;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float jump_power;
    [SerializeField] private int max_health;
    private int health;
    [SerializeField] private Slider healthbar;
    public Transform cam;
    private float xRotation;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        health = max_health;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        var mouseX = (Input.GetAxis("Mouse X") * mouse_sensitivity * Time.deltaTime);
        var mouseY = (Input.GetAxis("Mouse Y") * mouse_sensitivity * Time.deltaTime);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        cam.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
        var move = (transform.forward * speed * Input.GetAxis("Vertical")) + (transform.right * speed * Input.GetAxis("Horizontal"));
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpcheck())
            {
                rb.AddForce(Vector3.up * jump_power, ForceMode.Impulse);
            }
             
        }

        if (Input.GetKeyDown(KeyCode.R) || health <= 0 || transform.position.y < - 100)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnCollisionEnter(Collision collision)

    { if (collision.collider.gameObject.CompareTag("Obstacle"))
        {
            health -= 10;
            healthbar.value = (float)health / max_health;
        }
        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            health -= 2;
            healthbar.value = (float)health / max_health;

        }
        if (collision.collider.gameObject.CompareTag("Bouncepad"))
        {
            rb.AddForce(Vector3.up * bounce_power, ForceMode.Impulse);
        }
    }
    private bool jumpcheck (){
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1.5f)) {
            return true;
        }
        return false;

    }
}
