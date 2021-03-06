using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    struct PlayerData
    {
        public int score;
        public int levels;
        public int playerclip;
        public int playerreserve;
        public int levelpickups;
        public int collectedpickups;
    }
    
    private GameObject m_Player = null;
    private static bool Playing = false;
    private static LevelManager Instance = null;  
    private static PlayerData PlyData;
    
    
    /*==============================
        Awake
        Called before the scene controller is initialized
    ==============================*/
 
    void Awake()
    {
        // Check if this instance already exists, if not, then set itself to this instance
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this) // If the instance already exists, but isn't us, then destroy ourselves.
        {
            Destroy(this.gameObject);
            return;
        }
        
        Playing = false;
        DontDestroyOnLoad(this.gameObject);
        StartNewGame();
    }
    
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "StartMenu")
            GameObject.Find("MusicManager").gameObject.GetComponent<MusicManager>().PlaySong("Music/Menu");
        if (!Playing && (SceneManager.GetActiveScene().name == "SampleScene" || SceneManager.GetActiveScene().name == "SampleSceneMultiplayer"))
        {
            StartNewGame();
        }
        
        if (Playing && SceneManager.GetActiveScene().name != "SampleScene" && SceneManager.GetActiveScene().name != "SampleSceneMultiplayer")
        {
            Playing = false;
            StartNewGame();
        }
    }
    
    public void StartNewGame()
    {
        Playing = true;
        PlyData.score = 0;
        PlyData.levels = 1;
        PlyData.levelpickups = 0;
        PlyData.playerclip = 0;
        PlyData.playerreserve = 0;
        PlyData.collectedpickups = 0;
    }
    
    public void LoadNextLevel()
    {
        Time.timeScale = 1.0f;
        PlyData.levels++;
        PlyData.levelpickups = 0;
        PlyData.collectedpickups = 0;
        PlyData.playerclip = this.m_Player.GetComponent<PlayerController>().GetPlayerAmmoClip();
        PlyData.playerreserve = this.m_Player.GetComponent<PlayerController>().GetPlayerAmmoReserve();
        SceneManager.LoadScene("SampleScene");
    }
    
    public int GetLevelCount()
    {
        return PlyData.levels;
    }
    
    public int GetScore()
    {
        return PlyData.score;
    }
    
    public int GetPlayerAmmoClip()
    {
        return PlyData.playerclip;
    }
    
    public int GetPlayerAmmoReserve()
    {
        return PlyData.playerreserve;
    }
    
    public int GetPickupCount()
    {
        return PlyData.levelpickups;
    }
    
    public int GetCollectedPickupCount()
    {
        return PlyData.collectedpickups;
    }
    
    public void SetPlayer(GameObject obj)
    {
        this.m_Player = obj;
    }
    
    public void IncrementPickups()
    {
        PlyData.levelpickups++;
    }
    
    public void GiveScore(int score)
    {
        PlyData.score += score;
    }
    
    public void PickedUpPickups()
    {
        PlyData.collectedpickups++;
    }
}