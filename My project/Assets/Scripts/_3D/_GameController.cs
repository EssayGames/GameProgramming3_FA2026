using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class _GameController : MonoBehaviour
{
    //for singleton classes we want to make sure that this class will be "protected"
    //what that means is that the "data" or variable of this class can be fetched publicly
    //BUT those variables can ONLY by set privated (aka within this class)
    public static _GameController instance { get; private set; }
    public UnityEvent updateUI;
    public CoinsUI coinInventory;

    public GameObject ThirdPersonRig;
    public Transform mainStartingTransform;
    public Vector3 loadPos;
    public Quaternion loadRot;

    public void Awake()
    {
        //this block of logic ensures that there are only ever going to be ONE instance of this class in our project
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            //this is a build-in `Action` within the SceneManager that requires a listener method
            //that takes two arguments: Scene & LoadSceneMode
            //This `Action` is called whenever a new Scene is loaded
            SceneManager.sceneLoaded += OnSceneLoad;
            DontDestroyOnLoad(this);
        }

    }

    public void Start()
    {
        updateUI.AddListener(coinInventory.addCoins);
    }

    //this is the receiver method of the sceneLoaded Action
    //it checks for what scene has been loaded using the scene's build index number
    //that number is set in the Build Profile(s) for the project
    public void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex == 0)
        {
            //the below logic checks to see if data has been loaded into loadPos
            //if loadPos is `blank` then the game spawns the player at the mainStartingTransform
            //if loadPos has data then the game spawns the player at the loadPos & loadRot spot
            if (loadPos == Vector3.zero)
            {
                //Calls the Instantation method using dynamic arguments for the position and rotation
                SpawnThirdPersonPrefab(mainStartingTransform.position, mainStartingTransform.rotation);
            }
            else
            {
                SpawnThirdPersonPrefab(loadPos, loadRot);
            }
        }
    }

    //a PUBLIC method we can call from outside this class to instantiate our ThirdPersonRig prefab
    //it takes two arguments, the position and rotation of where we want to spawn the ThirdPersonRig prefab
    public void SpawnThirdPersonPrefab(Vector3 pos, Quaternion rot)
    {
        Instantiate(ThirdPersonRig, pos, rot);
    }

    //this method is called by the trigger of our loading zone(s) when we exit this scene
    //so that when we reload the `3D_demo` scene, we use the loadPos and loadRot data
    public void loadLocationData(Vector3 pos, Quaternion rot)
    {
        loadPos = pos;
        loadRot = rot;
    }

    public void coinGot()
    {
        updateUI.Invoke();
        Debug.Log("YOU HAVE INVOKED THE UI UPDATE!");
    }
}
