using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rbd;

    public static int killsCount = 0;
    

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] public  int enemies;
    public static int enemiesNum;

    [SerializeField] Transform jumpCheck;
    [SerializeField] LayerMask floor;

    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource killSound;

    [SerializeField] Text killed;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rbd.velocity = new Vector3(horizontalInput * moveSpeed, rbd.velocity.y, verticalInput * moveSpeed);

        if (Input.GetKeyDown("space") && Grounded())
        {
            Jump();
        }
    }

    void Jump()
    {
        rbd.velocity = new Vector3(rbd.velocity.x, jumpForce, rbd.velocity.z);
        jumpSound.Play();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            killSound.Play();
            Jump();

            killsCount++;
            enemiesNum = enemies;
            killed.text = "Killed: " + killsCount + " / " + enemiesNum;
        }
    }


    bool Grounded()
    {
        return Physics.CheckSphere(jumpCheck.position, .1f, floor);
    }
}
