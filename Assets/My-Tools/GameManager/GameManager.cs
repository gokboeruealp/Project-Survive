using System.Collections.Generic;
using UnityEngine;

namespace GokboerueTools
{
    public class GameManager : MonoBehaviour, IManager
    {
        #region Variables
        private static GameManager _i;
        public static GameManager i
        {
            get
            {
                if (_i == null)
                {
                    _i = Instantiate(Resources.Load<GameObject>("GameManager")).GetComponent<GameManager>();
                }

                return _i;
            }
        }
        #endregion

        #region Unity Methods
        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            Debug.Log("Game Manager Initialized");

            DontDestroyOnLoad(gameObject);
        }

        public void OnApplicationQuit()
        {
            Debug.LogWarning("Application Quit");
        }
        #endregion
    }
}