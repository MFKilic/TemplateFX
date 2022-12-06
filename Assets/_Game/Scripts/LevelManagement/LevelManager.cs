using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

namespace TemplateFx
{
    [DefaultExecutionOrder(-1)]
    public class LevelManager : Singleton<LevelManager>
    {

        public Transform enviromentHolderTransform;
        public Transform characterHolderTransform;

        public EventManager eventManager;
        public Datas datas;
        private void Awake()
        {
            eventManager = gameObject.AddComponent<EventManager>();
            datas = gameObject.AddComponent<Datas>();
        }

        private void OnEnable()
        {
            GameState.Instance.OnPrepareNewGameEvent += OnPrepareNewGameEvent;
        }

        private void OnDisable()
        {
            GameState.Instance.OnPrepareNewGameEvent -= OnPrepareNewGameEvent;
        }
        private void OnPrepareNewGameEvent()
        {
            ClearLevelALLLevelObjects();

            CreatingNewLevelObjects();
        }

        void Start()
        {
            GameState.Instance.OnPrepareNewGame();
        }

        

        private void ClearLevelALLLevelObjects()
        {
            if (enviromentHolderTransform != null)
            {
                Transform[] enviromentHolderTransformArray = enviromentHolderTransform.GetComponentsInChildren<Transform>(true);
                foreach (Transform trChild in enviromentHolderTransformArray)
                {
                    if (trChild.parent == enviromentHolderTransform)
                    {
                        Destroy(trChild.gameObject);
                    }
                }
            }
            if (characterHolderTransform != null)
            {
                Transform[] characterHolderTransformArray = characterHolderTransform.GetComponentsInChildren<Transform>(true);
                foreach (Transform trChild in characterHolderTransformArray)
                {
                    if (trChild.parent == characterHolderTransform)
                    {
                        Destroy(trChild.gameObject);
                    }
                }
            }
        }

        private void CreatingNewLevelObjects()
        {

        }
    }

}

