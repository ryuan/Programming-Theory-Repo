using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurnDirection
{
    Left,
    Right
}

public class Enemy : MonoBehaviour
{
    public float speed;
    public float turnRadius;
    public TurnDirection turnDirection;

    [SerializeField]
    private GameObject meatPrefab;

    private GameManager gameManager;
    private int dirMult;
    private Vector3 rotationAxis;

    // Start is called before the first frame update
    void Start()
    {
        if (turnDirection == TurnDirection.Left)
        {
            dirMult = -1;
        }
        else if (turnDirection == TurnDirection.Right)
        {
            dirMult = 1;
        }

        rotationAxis = transform.position + Vector3.right * dirMult * turnRadius;

        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RunCircle();
    }

    protected virtual void RunCircle()
    {
        transform.RotateAround(rotationAxis, Vector3.up, speed * dirMult * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bone"))
        {
            Instantiate(meatPrefab, transform.position + Vector3.up, meatPrefab.transform.rotation);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.isGameOver = true;
        }
    }
}
