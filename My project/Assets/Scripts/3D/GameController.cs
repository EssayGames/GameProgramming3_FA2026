using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using StarterAssets;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    public UnityEvent coinGot;
    public List<string> collectedCoinIDs;
    public GameObject coinUI;
    public GameObject FPS_Prefab;

    public Transform mainLoadLocation;
    public Vector3 load_loc;
    public Quaternion load_rot;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void Start()
    {
        //CoinsUI cUI = coinUI.GetComponent<CoinsUI>();
        //coinGot.AddListener(cUI.addCoins);
        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex == 0)
        {
            if(load_loc == Vector3.zero)
            {
                loadFPS(mainLoadLocation.position, mainLoadLocation.rotation);
            }
            else
            {
                loadFPS(load_loc, load_rot);
            }

            loadCoins();
        }
        else
        {
            Debug.Log("Main Scene Not Loaded");
        }
    }

    public void setMainLoc(Transform loc)
    {
        load_loc = loc.position;
        load_rot = loc.rotation;
    }

    public void loadFPS(Vector3 pos, Quaternion rot)
    {
        Instantiate(FPS_Prefab, pos, rot);
    }

    public void updateCoins(string coinID)
    {
        collectedCoinIDs.Add(coinID);
        coinGot.Invoke();
    }

    public void loadCoins()
    {
        CoinGrab[] allCoinsInScene = FindObjectsByType<CoinGrab>();
        
        if(collectedCoinIDs != null)
        {
            foreach (CoinGrab coin in allCoinsInScene)
            {
                if (collectedCoinIDs.Contains(coin.coinID))
                {
                    Destroy(coin.gameObject);
                }
            }
        }
    }

    public void setPlayerMovement(bool b)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        ThirdPersonController tpc = player.GetComponent<ThirdPersonController>();
        
        if (b)
        {
            tpc.enabled = false;
            //tpc.MoveSpeed = 0;
            //tpc.LockCameraPosition = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            tpc.enabled = true;
            //tpc.MoveSpeed = 2;
            //tpc.LockCameraPosition = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    }

}
