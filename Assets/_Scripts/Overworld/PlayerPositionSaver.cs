using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.SceneManagement;

public class PlayerPositionSaver : MonoBehaviour
{
    public GameObject player;
    private Vector3 pos;
    private string saveString; 

    private void Start()
    {
        try
        {
            SetLoadedPosition();
        }
        catch
        {
            SavePosition();
        }
    }

    public void SetLoadedPosition()
    {
        player.transform.position = LoadPosition();
    }

    public void SavePosition()
    {
        pos = player.transform.position;

        StringBuilder playerPos = new StringBuilder();
        playerPos.Append(pos.x).Append(" ").Append(pos.y).Append(" ").Append(pos.z);
        saveString = playerPos.ToString();

        PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "playerPosition", saveString);

        Debug.Log("Saved the following data: " + saveString);
    }

    public Vector3 LoadPosition()
    {
        saveString = PlayerPrefs.GetString(SceneManager.GetActiveScene().name + "playerPosition");
        string[] values = saveString.Split(' ');


        Vector3 positionToLoad = new Vector3(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2]));


        return positionToLoad;
    }

}
