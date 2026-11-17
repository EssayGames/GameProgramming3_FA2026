using UnityEngine;

public interface IDataHandler
{
    public void LoadData(GameData data);
    public void SaveData(ref GameData data);
}
