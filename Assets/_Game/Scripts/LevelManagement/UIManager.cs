using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;


namespace TemplateFx
{
    public class UIManager : Singleton<UIManager>
    {
        public ViewInit viewInit;
        public ViewPlay viewPlay;
        public ViewFinish viewFinish;
        private void OnEnable()
        {
            LevelManager.Instance.eventManager.OnFirstInputEvent += OnFirstInputEvent;
            GameState.Instance.OnPrepareNewGameEvent += OnPrepareNewGameEvent;
            GameState.Instance.OnFinishGameEvent += OnFinishGameEvent;
        }

       

        private void OnDisable()
        {
            LevelManager.Instance.eventManager.OnFirstInputEvent -= OnFirstInputEvent;
            GameState.Instance.OnPrepareNewGameEvent -= OnPrepareNewGameEvent;
        }

        private void OnFirstInputEvent()
        {
            
        }

       
        private void OnPrepareNewGameEvent()
        {
            viewInit.gameObject.SetActive(false);
            viewPlay.gameObject.SetActive(true);
            viewPlay.ViewPlayStart();
            viewFinish.gameObject.SetActive(false);
        }

        private void OnFinishGameEvent(LevelFinishStatus levelFinish)
        {
            viewInit.gameObject.SetActive(false);
            viewPlay.gameObject.SetActive(false);
            viewFinish.gameObject.SetActive(true);
            viewFinish.ManuelStart();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }


}

