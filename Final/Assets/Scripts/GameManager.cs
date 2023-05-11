using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int counter = 0;
    public int target = 3;   // will be changed based on number of levels

    public TextMeshProUGUI beginText;
    public TextMeshProUGUI endText;

    public Image arrowImg;
    private float arrowImgOpacity;

    public GameObject backgroundImage;
    public Material[] bgMaterials = new Material[4];

    public int Counter
    {
        get { return counter;}
        set
        {
            counter = value;
            Debug.Log(counter);
            UpdateBG();
        }
    }
    
    private void Awake()
    {
        // singleton
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // bg img initialize
        backgroundImage.GetComponent<Renderer>().material = bgMaterials[0];
    }

    // Start is called before the first frame update
    void Start()
    {
        arrowImgOpacity = arrowImg.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        arrowImg.color = new Vector4(arrowImg.color.r, arrowImg.color.g, arrowImg.color.b, 255 * Mathf.Sin(Time.time * 6));
        // Debug.Log(arrowImg.color.a);

        if (Input.GetKeyUp("space"))
        {
            Counter++;
            Debug.Log(Counter);
        }
        
        
        if (Counter == target || Input.GetKey(KeyCode.A))
        {
            Debug.Log("Counter: " + Counter);
            Debug.Log("Target: " + target);
            Debug.Log("target achieved");
            ThrowPlane.Instance.gameObject.SetActive(false);
            endText.gameObject.SetActive(true);
        }
    }

    void UpdateBG()
    {
        backgroundImage.GetComponent<Renderer>().material = bgMaterials[counter];
    }
}
