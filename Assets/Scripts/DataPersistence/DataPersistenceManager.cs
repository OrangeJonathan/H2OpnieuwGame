using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string FileName;
    
    private GameData GameData;
    
    private List<IDataPersistence> DataPersistenceObjects;

    private FileDataHandler DataHandler;

    // Met '{get; private set;}' zorg je ervoor dat de instance op 'read-only' staat.
    public static DataPersistenceManager instance {get; private set;}

    private void Awake()
    {
        // Check of er maar 1 Data Persistence Manager is in de scene.
        if (instance != null)
        {
            Debug.LogError("More than one Data Persistence Manager in the scene.");
        }
        instance = this;

        this.DataHandler = new FileDataHandler(Application.persistentDataPath, FileName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded Called");
        this.DataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    private void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("OnSceneUnloaded Called");
        SaveGame();
    }

    // Aanmaken van nieuwe 'savefile'.
    public void NewGame()
    {
        this.GameData = new GameData();
    }

    // Opslaan van gamedata.
    public void SaveGame()
    {
        // TODO - De nieuwste data naar andere scripts sturen zodat ze kunnen updaten.
        foreach (IDataPersistence DataPersistenceObj in DataPersistenceObjects)
        {
            DataPersistenceObj.SaveData(ref GameData);
        }

        // TODO - Opslaan van data.
        DataHandler.Save(GameData);
    }

    // Laden van gamedata.
    public void LoadGame()
    {
        this.GameData = DataHandler.Load();

        // Als er geen gamedata is, dan nieuwe game maken.
        if (this.GameData == null)
        {
            Debug.Log("Geen data gevonden");
            NewGame();
        }

        // TODO - Geladen data sturen naar de verschillende scripts.
        foreach (IDataPersistence DataPersistenceObj in DataPersistenceObjects)
        {
            DataPersistenceObj.LoadData(GameData);
        }
    }
    
    // Data opslaan als de applicatie afgesloten wordt.
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> DataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(DataPersistenceObjects);
    }
}
