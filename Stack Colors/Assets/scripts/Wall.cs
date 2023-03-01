using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Color doorColor; 
    public bool fullColor;
    public string newTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            foreach (Renderer renderer in other.GetComponentsInChildren<Renderer>())
            {
                renderer.material.color = doorColor;
            }
        }

       
        if (other.tag == "Player" && fullColor)
        {
            
            GameObject[] objectsToChange = GameObject.FindGameObjectsWithTag("ObjectToChange");
           
            foreach (GameObject obj in objectsToChange)
            {              
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = doorColor;
                }
                obj.tag = newTag;
            }
        }

    }
}
