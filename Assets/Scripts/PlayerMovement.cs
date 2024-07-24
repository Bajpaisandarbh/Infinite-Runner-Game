using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rp;
    public float forwardForce;
    public float sideForce;
    public void FixedUpdate()
    {
        rp.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            // Move right
            rp.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            // Move left
            rp.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        }
        if (rp.position.y < -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
