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
            if (GameManager.Instance.LevelCounter == 0)
            {
                DisplayLetter(0);
            }
            if (GameManager.Instance.LevelCounter == 1)
            {
                DisplayLetter(1);
            }
            if (GameManager.Instance.LevelCounter == 2)
            {
                DisplayLetter(2);
            }
            
            if (GameManager.Instance.LevelCounter != 3)
            {
                GameManager.Instance.hitWindowText.gameObject.SetActive(true);    
            }
            GameManager.Instance.levelUpgraded = true;
            Debug.Log("hit window!");
            GameManager.Instance.LevelCounter++;
        }
    }

    void DisplayLetter(int idx)
    {
        if (idx == 0)
        {
            GameManager.Instance.letter0.gameObject.SetActive(true);
        }
        if (idx == 1)
        {
            GameManager.Instance.letter1.gameObject.SetActive(true);
        }
        if (idx == 2)
        {
            GameManager.Instance.letter2.gameObject.SetActive(true);
        }
    }
    
}
