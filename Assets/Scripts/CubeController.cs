using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [Tooltip("Changer speed cube")]
    [SerializeField]
    private float speed = 5f;

    void Update()
    {
         float moveInput = Input.GetAxis("Vertical"); 
        Vector3 moveDirection = transform.forward * moveInput * speed * Time.deltaTime; 

        transform.position += moveDirection;
    }
}
