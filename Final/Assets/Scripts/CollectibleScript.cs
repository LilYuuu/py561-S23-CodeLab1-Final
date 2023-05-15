using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    // public int collectibleCounter = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.ScoreCounter++;
            GameManager.Instance.collectibles.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
