using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWindow : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.Counter++;
            Debug.Log("hit window!");
        }
    }
}
