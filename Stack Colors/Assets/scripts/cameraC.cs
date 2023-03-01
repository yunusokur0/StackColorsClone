using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraC : MonoBehaviour
{

    [SerializeField] private Transform target;
    private Vector3 offset;
    [SerializeField] private float lerpTime;


    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        Vector3 _newPos = Vector3.Lerp(transform.position, offset + target.position, lerpTime * Time.deltaTime);
        transform.position = _newPos;
    
    }
}
