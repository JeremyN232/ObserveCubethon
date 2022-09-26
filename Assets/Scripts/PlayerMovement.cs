using UnityEngine;

    public class PlayerMovement : MonoBehaviour
{

        public Rigidbody rb;

        public float forwardForce = 2000f;
        public float sideForce = 1000f;
        public GameManager gm;

 

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Speedup")
            {
                Debug.Log("speed up");
                forwardForce = 4500f;
                gm.speedUp();
            }
            if (other.tag == "Slowdown")
            {
                forwardForce = 1000f;
                gm.slowDown();
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);

            if (Input.GetKey("d"))
            {
                rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if (Input.GetKey("a"))
            {
                rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if (rb.position.y < -1.25f)
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }