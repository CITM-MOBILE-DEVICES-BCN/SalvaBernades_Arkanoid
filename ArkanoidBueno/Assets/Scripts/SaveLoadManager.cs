using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveLoadManager : MonoBehaviour
{


    [System.Serializable]

    public class PlayerData
    {
        public int currentScore;
        public int highScore;
        public int lives;
        public string scena;
    }

    string comprobar;
    string filePath;
    private void Awake()
    {
        filePath = Application.dataPath + "/SavedFiles/setting.json";

      
        if (!System.IO.Directory.Exists(Application.dataPath + "/SavedFiles"))
        {
            System.IO.Directory.CreateDirectory(Application.dataPath + "/SavedFiles");
        }
    }

    public PlayerData facts;
    public void SerializePlayerData()
    {

        facts.highScore = FindObjectOfType<GameManager>().highScore;
        facts.currentScore = FindObjectOfType<GameManager>().score;
        facts.lives = FindObjectOfType<GameManager>().lives;
        facts.scena = SceneManager.GetActiveScene().name;


        JsonUtility.ToJson(facts);
        string json = JsonUtility.ToJson(facts);

        PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);

        System.IO.File.WriteAllText(filePath, json);

        comprobar = loadedData.currentScore + " " + loadedData.highScore + " " + loadedData.scena + " " + loadedData.lives;
       

    }

    public void DeSerializePlayerData()
    {
        if (System.IO.File.Exists(filePath))
        {


            string json = System.IO.File.ReadAllText(filePath);

            

            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);
            // Verificar si el archivo existe


            SceneManager.LoadScene(loadedData.scena);

            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.highScore = loadedData.highScore;
                gameManager.score = loadedData.currentScore;
                gameManager.lives = loadedData.lives;
            }
           
            Time.timeScale = 1.0f;
        }
        
    }




}
