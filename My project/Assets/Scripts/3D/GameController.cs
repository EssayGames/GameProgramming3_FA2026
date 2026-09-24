using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }
    public UnityEvent coinGot;
    public GameObject coinUI;

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
    }

    public void Start()
    {
        CoinsUI cUI = coinUI.GetComponent<CoinsUI>();
        //coinGot.AddListener(cUI.addCoins);
    }

    public void updateCoins()
    {
        Debug.Log("Update Coins!");
        coinGot.Invoke();
    }

}
