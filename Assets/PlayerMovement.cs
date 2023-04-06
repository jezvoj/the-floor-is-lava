using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput;
        float verticalInput;
        Vector3 movementUpdate;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Debug.Log("Horizontal: " + horizontalInput + ", Vertical: " + verticalInput);

        movementUpdate = new Vector3(horizontalInput, 0, verticalInput).normalized;

        transform.position += (movementUpdate * Time.deltaTime);
        

    }
}
