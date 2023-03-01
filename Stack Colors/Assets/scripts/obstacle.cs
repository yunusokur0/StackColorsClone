using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    private bool hasCollided = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasCollided && other.gameObject.CompareTag("Player"))
        {
            PlayerMove player = other.gameObject.GetComponentInParent<PlayerMove>();
            if (player != null && player.cubes.Count > 0)
            {
                List<GameObject> childObjects = player.cubes;
                int lastIndex = childObjects.Count - 1;
                Destroy(childObjects[lastIndex]);
                childObjects.RemoveAt(lastIndex);
                hasCollided = true;
            }
            else if (player.cubes.Count <= 0 )
            {
                Time.timeScale = 0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (hasCollided && other.gameObject.CompareTag("Player"))
        {
            hasCollided = false;
        }
    }


}
