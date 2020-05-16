using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rigidBody;
    private Vector3 changePosition;

    private void Awake() 
    {
        this.rigidBody = this.GetComponent<Rigidbody2D>();    
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        changePosition = Vector3.zero;
        changePosition.x = Input.GetAxisRaw ("Horizontal") * Time.deltaTime * speed;
        changePosition.y = Input.GetAxisRaw ("Vertical") * Time.deltaTime * speed;
        if (changePosition != Vector3.zero)
        {
            transform.Translate (new Vector3 (changePosition.x, changePosition.y));
        }
    }
}
