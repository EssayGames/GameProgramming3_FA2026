using UnityEngine;
using UnityEngine.Events;

public class _GameController : MonoBehaviour
{
    //for singleton classes we want to make sure that this class will be "protected"
    //what that means is that the "data" or variable of this class can be fetched publicly
    //BUT those variables can ONLY by set privated (aka within this class)
    public static _GameController instance { get; private set; }
    public UnityEvent updateUI;

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
        }

        DontDestroyOnLoad(this);
    }

    public void coinGot()
    {
        updateUI.Invoke();
        Debug.Log("YOU HAVE INVOKED THE UI UPDATE!");
    }
}
