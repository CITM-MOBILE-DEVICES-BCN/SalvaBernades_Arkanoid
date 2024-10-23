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
        public int lives;
        public int highScore;

    }


   
}
