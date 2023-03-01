using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;
    public List<GameObject> cubes = new List<GameObject>();
    public float speed;
    private Vector3 firstTouchPosition;
    private Vector3 curTouchPosition;
    private float finalTouchX;
    public float sensitivityMultiplier = 0.01f;
    public float xBound;
   
    void Awake()
    {
        instance = this;
    }


    void Update()
    {
        Move();
        
    }

    

    private void Move()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        if (Input.GetMouseButtonDown(0))
        {

            firstTouchPosition = Input.mousePosition;
        }


        if (Input.GetMouseButton(0))
        {
            curTouchPosition = Input.mousePosition;
            Vector2 touchDelta = (curTouchPosition - firstTouchPosition);
            finalTouchX = (transform.position.x + (touchDelta.x * sensitivityMultiplier));
            finalTouchX = Mathf.Clamp(finalTouchX, -xBound, xBound);
            transform.position = new Vector3(finalTouchX, transform.position.y, transform.position.z);
            firstTouchPosition = Input.mousePosition;
        }
    }
}
