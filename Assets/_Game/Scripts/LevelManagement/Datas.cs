using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TemplateFx
{
    public class Datas : MonoBehaviour
    {
        private const string levelString = "Level";

        public int level;


       

        private void OnEnable()
        {
            GameState.Instance.OnPrepareNewGameEvent += OnPrepareNewGameEvent;
            GameState.Instance.OnFinishGameEvent += OnFinishGameEvent;
        }

        private void OnDisable()
        {
            GameState.Instance.OnPrepareNewGameEvent -= OnPrepareNewGameEvent;
            GameState.Instance.OnFinishGameEvent -= OnFinishGameEvent;
        }
        private void Awake()
        {
            level = PlayerPrefs.GetInt(levelString);
        }
        private void OnPrepareNewGameEvent()
        {
            level = PlayerPrefs.GetInt(levelString);
        }

        private void OnFinishGameEvent(LevelFinishStatus levelFinishStatus)
        {
            if(levelFinishStatus == LevelFinishStatus.WIN)
            {
                PlayerPrefs.SetInt(levelString, level + 1);
                level = PlayerPrefs.GetInt(levelString);
            }
            else
            {
                ///
            }
        }
        
    }
}

