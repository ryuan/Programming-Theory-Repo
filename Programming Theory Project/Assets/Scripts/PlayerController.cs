using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float throwForce;

    [SerializeField]
    private GameObject bonePrefab;
    [SerializeField]
    private float gravityMod;

    private GameManager gameManager;
    private Animator animator;
    private Rigidbody playerRb;
    private bool isGrounded;
    private bool isThrowing;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isThrowing)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Run();
            }
            else
            {
                Stop();
            }

            if (Input.GetAxis("Horizontal") != 0)
            {
                Turn();
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.R) && gameManager.BonesCollected > 0 && isGrounded)
            {
                Throw();
            }
        }
    }

    void Run()
    {
        animator.SetFloat("Speed_f", 0.8f);
        transform.LookAt(transform.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }

    void Stop()
    {
        //animator.SetBool("Static_b", false);
        animator.SetFloat("Speed_f", 0.0f);
    }

    void Turn()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal"));
    }

    void Jump()
    {
        animator.SetTrigger("Jump_trig");
        isGrounded = false;
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void Throw()
    {
        isThrowing = true;
        gameManager.BonesCollected -= 1;

        StartCoroutine(Throwing());
    }

    IEnumerator Throwing()
    {
        animator.SetInteger("Animation_int", 10);
        animator.speed *= 2;

        yield return new WaitForSeconds(0.75f);

        GameObject projectile = Instantiate(bonePrefab, transform.position, bonePrefab.transform.rotation);
        projectile.transform.Translate(transform.forward * 3 + transform.up * 2, Space.Self);

        projectile.AddComponent<Rigidbody>();
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        projectileRb.AddForce((transform.forward + Vector3.up * 0.8f) * throwForce, ForceMode.Impulse);
        projectileRb.AddTorque(Vector3.forward * throwForce, ForceMode.Impulse);

        Collider projectileCol = projectile.GetComponent<Collider>();
        projectileCol.isTrigger = false;

        yield return new WaitForSeconds(0.25f);

        animator.SetInteger("Animation_int", 0);
        animator.speed /= 2;
        isThrowing = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
