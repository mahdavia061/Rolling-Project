
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 1250f;
    public float sideForces = 500f;

    public LayerMask groundLayers;
    public float jumpSpeed = 0.6f;

    public SphereCollider col;

    private void Start()
    {
        col = GetComponent<SphereCollider>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce*Time.deltaTime);

        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(sideForces * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-sideForces * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        }
        
        
            if (isGrounded() && Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            }
        
        
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        if (rb.position.y<-1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    private bool isGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }
}
