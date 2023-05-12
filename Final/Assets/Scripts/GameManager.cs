using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

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
    public bool spawned = false;
    public List<GameObject> collectibles;
    // public GameObject[] collectibles = new GameObject[3];
        
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
    }

    // Update is called once per frame
    void Update()
    {
        arrowImg.color = Color.Lerp(new Color(arrowImg.color.r, arrowImg.color.g, arrowImg.color.b, 1), new Color(arrowImg.color.r, arrowImg.color.g, arrowImg.color.b, 0), Mathf.Sin(Time.time * 5));
        
        // For debug use
        if (Input.GetKeyUp("space"))
        {
            Counter++;
            Debug.Log(Counter);
        }
        
        // Level 2： with collectibles
        if (Counter == 2)
        {
            if (!spawned)
            {
                // Spawn three collectibles
                for (var i = 0; i < 3; i++)
                {
                    GameObject newCollectible = spawner.SpawnCollectible(new Vector3(0, Random.Range(-4.0f, 6.0f), Random.Range(3.0f, 150.0f)));
                    collectibles.Add(newCollectible);
                    // collectibles[i] = newCollectible;
                }
                spawned = true;
            }
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
