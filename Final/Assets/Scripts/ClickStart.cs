using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickStart : MonoBehaviour
{
    private void OnMouseUp()
    {
        SceneManager.LoadScene(1);
    }
}
