using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // FIELDS

    // Config
    [SerializeField] private float speed = 6;

    // State
    private Vector3 changePosition;
    private bool isMoving = false;

    // Cached
    private Rigidbody2D rigidBody;
    private Animator animator;

    // MONOBEHAVIOUR FUNCTIONS

    private void Awake () 
    {
        this.rigidBody = this.GetComponent<Rigidbody2D> ();
        this.animator = this.GetComponent<Animator>();
    }

    private void Start ()
    {
        
    }

    private void Update ()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        changePosition = Vector3.zero;
        changePosition.x = horizontal * Time.deltaTime * speed;
        changePosition.y = vertical * Time.deltaTime * speed;
        UpdateAnimationAndMove (horizontal, vertical);
    }

    private void UpdateAnimationAndMove(float horizontal, float vertical)
    {
        if (changePosition != Vector3.zero)
        {
            transform.Translate(new Vector3(changePosition.x, changePosition.y));
            animator.SetFloat("moveX", horizontal);
            animator.SetFloat("moveY", vertical);
        }

        isMoving = (changePosition != Vector3.zero);
        animator.SetBool ("isMoving", isMoving);
    }
}
