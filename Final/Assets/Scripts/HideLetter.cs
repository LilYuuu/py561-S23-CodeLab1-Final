using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLetter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            this.gameObject.SetActive(false);
        }
    }
}
