using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using StarterAssets;

public class GameController : MonoBehaviour
{
    //this instance variable is the static reference to this class
    //it can only be overwritten within this class (the private set determines that)
    public static GameController instance { get; private set; }
    public coinAdd coinUpdate;
    public coinUI coinHUD;
    public int currentCoins = 0;

    public Transform startingLoc;
    public Vector3 loadLoc;
    public Quaternion loadRot;
    public bool firstSceneloaded = false;
    public GameObject ThirdPersonRig;

    public List<string> collectCoinIDs;

    public void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);

            //this line uses the `sceneLoaded` UnityAction
            //we subscribe the OnSceneLoaded method to this action, which "fires" whenever a new scene is loaded
            SceneManager.sceneLoaded += OnSceneLoaded;
            //Debug.Log("Loaded Scene: " + SceneManager.GetActiveScene());
        }

    }

    //this method receives the `sceneLoaded` UnityAction and requires the Scene and LoadSceneMode arguments
    //we use this method to check what current scene has been loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex == 0)
        {
            if(!firstSceneloaded)
            {
                Debug.Log("Spawned Character at starting Location");
                SpawnCharacter(startingLoc.position, startingLoc.rotation);
                firstSceneloaded = true;
            }
            else
            {
                Debug.Log("Spawned Character at new Location");
                SpawnCharacter(loadLoc, loadRot);
            }

            loadCoins();
        }
    }

    public void SpawnCharacter(Vector3 loc, Quaternion rot)
    {
        Debug.Log("SPAWNED THIRD PERSON");
        Instantiate(ThirdPersonRig, loc, rot);
    }

    //the below method is a `setter` method for this singleton
    //it gets called by other GameObjects and classes when we enter/exit "loading zones"
    public void setSpawnPoint(Vector3 loc, Quaternion rot)
    {
        loadLoc = loc;
        loadRot = rot;
    }

    public void coinCollect(string coinID)
    {
        //Debug.Log("CoinID: " + coinID);
        collectCoinIDs.Add(coinID);
        currentCoins++;
        coinUpdate.AddListener(coinHUD.addCoins);
        coinUpdate.Invoke(currentCoins);
    }

    public void loadCoins()
    {
        coinGrab[] allCoinsInScene = FindObjectsByType<coinGrab>();

        if(collectCoinIDs != null)
        {
            foreach(coinGrab coin in allCoinsInScene)
            {
                if (collectCoinIDs.Contains(coin.coinID))
                {
                    Destroy(coin.gameObject);
                }
            }
        }
    }

    //this is a `setter` method for the `coinHUD` variable in this class
    public void setUI(coinUI ui)
    {
        coinHUD = ui;
    }

    public void setPlayerMovement(bool b)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        ThirdPersonController tpc = player.GetComponent<ThirdPersonController>();

        if (b)
        {
            tpc.enabled = false;
        }
        else
        {
            tpc.enabled = true;
        }
    }
}

[System.Serializable]
public class coinAdd : UnityEvent<int>
{

}
