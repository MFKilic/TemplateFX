using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

namespace TemplateFx
{
    public enum LevelFinishStatus
    {
        WIN,LOSE
    }

    [DefaultExecutionOrder(-1)]
    public class GameState : Singleton<GameState>
    {
        public enum GameStatus
        {
            NONE,
            PREPARING,
            PLAYING,
            PAUSED,
            RESUMING,
            FINISHED,
        }

        private bool firstInput;

        private bool playing;

        public GameStatus gameStatus;

        [HideInInspector] LevelFinishStatus levelFinishStat;

        public delegate void OnPrepareNewGameDelegate();
        public event OnPrepareNewGameDelegate OnPrepareNewGameEvent;

        public delegate void OnPlayingGameDelegate();
        public event OnPlayingGameDelegate OnPlayingGameEvent;

        public delegate void OnPausingGameDelegate();
        public event OnPausingGameDelegate OnPausingGameEvent;

        public delegate void OnResumingGameDelegate();
        public event OnResumingGameDelegate OnResumingGameEvent;

        public delegate void OnFinishGameDelegate(LevelFinishStatus levelFinish);
        public event OnFinishGameDelegate OnFinishGameEvent;

        public GameStatus GetGameStatus()
        {
            return gameStatus;
        }

        public LevelFinishStatus GetLevelStatus()
        {
            return levelFinishStat;
        }

        public bool IsPlaying()
        {
            return playing;
        }

        public void OnPrepareNewGame()
        {
            if(GetGameStatus() != GameStatus.PREPARING)
            {
                playing = true;
                firstInput = false;
                OnPrepareNewGameEvent?.Invoke();
                Debug.Log("_OnPrepareNewGameIsCalling_");
                gameStatus = GameStatus.PREPARING;
            }
            
        }

        public void OnPlayingNewGame()
        {
            if(IsPlaying() == false)
            {
                return;
            }
            if (GetGameStatus() != GameStatus.PLAYING)
            {
                OnPlayingGameEvent?.Invoke();
                Debug.Log("_OnPlayingNewGameIsCalling_");
                gameStatus = GameStatus.PLAYING;
            }
        }

        public void OnPausingGame()
        {
            if (IsPlaying() == false)
            {
                return;
            }
            if (GetGameStatus() != GameStatus.PAUSED)
            {
                OnPausingGameEvent?.Invoke();
                Debug.Log("_OnPausingGameIsCalling_");
                gameStatus = GameStatus.PAUSED;
            }
        }

        public void OnResumingGame()
        {
            if (IsPlaying() == false)
            {
                return;
            }
            if (GetGameStatus() != GameStatus.RESUMING)
            {
                OnResumingGameEvent?.Invoke();
                Debug.Log("_OnResumingGameIsCalling_");
                gameStatus = GameStatus.RESUMING;
            }
        }

        public void OnFinishGame(LevelFinishStatus levelFinishStatus)
        {
            if (GetGameStatus() != GameStatus.FINISHED)
            {
                playing = false;
                firstInput = false;
                levelFinishStat = levelFinishStatus;
                OnFinishGameEvent?.Invoke(levelFinishStatus);
                Debug.Log("_OnFinishGameIsCalling_");
                gameStatus = GameStatus.FINISHED;
            }
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                OnFinishGame(LevelFinishStatus.WIN);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                OnFinishGame(LevelFinishStatus.LOSE);
            }

            if (firstInput)
            {
                return;
            }

            if(Input.GetMouseButtonDown(0))
            {
                if(!firstInput)
                {
                    LevelManager.Instance.eventManager.OnFirstInputIsPressed();
                    OnPlayingNewGame();
                    firstInput = true;
                }
               
            }
        }
    }

}

