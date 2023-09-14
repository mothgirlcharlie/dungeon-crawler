using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float sprintMultiplier = 1.5f;
    private Vector3 moveAxis = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveAxis.x = Input.GetAxisRaw("Horizontal");
        moveAxis.y = Input.GetAxisRaw("Vertical");
        Move();
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveAxis *= sprintMultiplier;
        }
        transform.position += moveAxis * moveSpeed * Time.deltaTime;
        
    }
}
