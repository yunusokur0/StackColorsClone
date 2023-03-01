using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Transform player;
    

    private void Awake()
    {   
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    

    private void OnTriggerEnter(Collider other)
    {     
        if (other.gameObject.CompareTag("NoStacked"))
        {           
            other.transform.parent = player;
            Vector3 lastParent = PlayerMove.instance.cubes[PlayerMove.instance.cubes.Count - 1].transform.localPosition;    
            other.transform.localPosition = lastParent + new Vector3(0, transform.localScale.x, 0) /3; 
            PlayerMove.instance.cubes.Add(other.gameObject);           
            other.tag = ("Player");
        }
    }
}
