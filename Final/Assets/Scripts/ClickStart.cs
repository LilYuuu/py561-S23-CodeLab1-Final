using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickStart : MonoBehaviour
{
    public GameObject planeObject;
    private Color defaultColor;
    public void Start()
    {
        defaultColor = planeObject.GetComponent<MeshRenderer>().material.color;
    }

    public void Update()
    {
        
        // arrowImg.color = Color.Lerp(new Color(arrowImg.color.r, arrowImg.color.g, arrowImg.color.b, 1), new Color(arrowImg.color.r, arrowImg.color.g, arrowImg.color.b, 0), Mathf.Sin(Time.time * 5));
        planeObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(new Color(defaultColor.r, defaultColor.g, defaultColor.b, 1), new Color(defaultColor.r, defaultColor.g, defaultColor.b, 0), Mathf.Sin(Time.time * 4));
    }

    private void OnMouseUp()
    {
        SceneManager.LoadScene(1);
    }
}
