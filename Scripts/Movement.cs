using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Camera cam;
    private Collider groundCollider;
    RaycastHit hit;
    Ray ray;

    public float rotationSpeed = 5f;
    public float moveSpeed = 5f;
    public bool isRotate;




    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        groundCollider = GameObject.Find("Ground").GetComponent<Collider>();
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isRotate = !isRotate;
        }

    }



    private void OnMouseDrag()
    {
        if (!isRotate)
        {
            //transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 11f));
            
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == groundCollider)
                {
                    transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * moveSpeed);
                }
            }
        }
        else
        {
            float xRotation = Input.GetAxis("Mouse X") * rotationSpeed;
            transform.Rotate(Vector3.down, xRotation);
        }

    }




}
