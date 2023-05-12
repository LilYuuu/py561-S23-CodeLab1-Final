using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Keep track of the levels
    public int counter = 0;
    public int target = 3;   // will be changed based on number of levels

    // Text display
    public TextMeshProUGUI beginText;
    public TextMeshProUGUI endText;

    // Arrow indication
    public Image arrowImg;
    private float arrowImgOpacity;

    // BG image array
    public GameObject backgroundImage;
    public Material[] bgMaterials = new Material[4];

    // Spawning collectibles
    public CollectibleSpawner spawner;

    // Properties of level counter
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
    
    // Singleton
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

        // BG img initialize
        backgroundImage.GetComponent<Renderer>().material = bgMaterials[0];
    }

    // Start is called before the first frame update
    void Start()
    {
        arrowImgOpacity = arrowImg.color.a;
        
        // Spawn three collectibles on start
        for (var i = 0; i < 3; i++)
        {
            spawner.SpawnCollectible(new Vector3(0, Random.Range(-4.0f, 6.0f), Random.Range(3.0f, 150.0f)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        arrowImg.color = new Vector4(arrowImg.color.r, arrowImg.color.g, arrowImg.color.b, 255 * Mathf.Sin(Time.time * 6));
        // Debug.Log(arrowImg.color.a);

        // For debug use
        if (Input.GetKeyUp("space"))
        {
            Counter++;
            Debug.Log(Counter);
        }
        
        // When game ends
        if (Counter == target || Input.GetKey(KeyCode.A))
        {
            Debug.Log("Counter: " + Counter);
            Debug.Log("Target: " + target);
            Debug.Log("Target achieved");
            ThrowPlane.Instance.gameObject.SetActive(false);
            endText.gameObject.SetActive(true);
        }
    }

    void UpdateBG()
    {
        backgroundImage.GetComponent<Renderer>().material = bgMaterials[counter];
    }
}
