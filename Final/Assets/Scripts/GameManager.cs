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
    public int levelCounter = 0;
    public int levelTarget = 3;   // will be changed based on number of levels
    // Update text info for level
    public TextMeshProUGUI levelValueText;
    public bool levelUpgraded = false;

    // Score
    public int scoreCounter = 0;
    public TextMeshProUGUI scoreDisplayText;
    public TextMeshProUGUI scoreValueText;
    
    // Text display
    public TextMeshProUGUI beginText;
    public TextMeshProUGUI endText;
    public TextMeshProUGUI level1HintText;
    public bool level1HintDisplayed = false;
    public TextMeshProUGUI level2HintText;
    public bool level2HintDisplayed = false;
    public TextMeshProUGUI hitWindowText;

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
    
    // Letters
    public Image letter0;
    public Image letter1;
    public Image letter2;
        
    // Properties of level counter
    public int LevelCounter
    {
        get { return levelCounter;}
        set
        {
            levelCounter = value;
            Debug.Log("Level: " + levelCounter);
            if (levelCounter < levelTarget)
            {
                Invoke("UpdateBG", 5f);    
            }
        }
    }
    
    public int ScoreCounter
    {
        get { return scoreCounter;}
        set
        {
            scoreCounter = value;
            Debug.Log("Score: " + scoreCounter);
            UpdateScoreText();
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
            LevelCounter++;
            Debug.Log("Level: " + LevelCounter);
        }
        
        // Remove hit window text
        if (levelUpgraded)
        {
            Invoke("HideHitWindowText", 2f);
        }
        
        // Level 1: keyboard control
        if (LevelCounter == 1)
        {
            Invoke("DisplayLevel1HintText", 5f);
        }
        
        // Level 2： with collectibles
        if (LevelCounter == 2)
        {
            if (!spawned)
            {
                spawned = true;
                Invoke("DisplayLevel2HintText", 5f);
                
                // Spawn three collectibles
                for (var i = 0; i < 3; i++)
                {
                    GameObject newCollectible = spawner.SpawnCollectible(new Vector3(0, Random.Range(-4.0f, 6.0f), Random.Range(3.0f, 150.0f)));
                    collectibles.Add(newCollectible);
                    // collectibles[i] = newCollectible;
                }
                Debug.Log("spawned: " + spawned);
                
            }
        }

        // When game ends
        if (LevelCounter == levelTarget || Input.GetKey(KeyCode.A))
        {
            Debug.Log("Game finished");
            ThrowPlane.Instance.gameObject.SetActive(false);
            endText.gameObject.SetActive(true);
            
            // Invoke("Restart", 5f);
        }
    }

    void UpdateBG()
    {
        backgroundImage.GetComponent<Renderer>().material = bgMaterials[levelCounter];
        levelValueText.text = (levelCounter + 1) + " / 3";
    }

    void UpdateScoreText()
    {
        scoreValueText.text = scoreCounter + " / 3";
    }

    void HideHitWindowText()
    {
        hitWindowText.gameObject.SetActive(false);
        levelUpgraded = false;
    }

    void DisplayLevel1HintText()
    {
        // arrowImg.gameObject.SetActive(true);
        level1HintText.gameObject.SetActive(true);
        level1HintDisplayed = false;
    }

    void DisplayLevel2HintText()
    {
        level1HintText.gameObject.SetActive(false);
        
        // arrowImg.gameObject.SetActive(true);
        level2HintText.gameObject.SetActive(true);
        scoreDisplayText.gameObject.SetActive(true);
        scoreValueText.gameObject.SetActive(true);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
