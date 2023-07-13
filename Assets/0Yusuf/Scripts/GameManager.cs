using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Y
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance { get => _instance; }

        private float _timer = 0;
        public float Timer
        {
            get => _timer;
            set => _timer = value;
        }
        private void Awake()
        {
            if (_instance == null)
                _instance = this;
        }
        void Update()
        {
            Timer += Time.deltaTime;
        }
    }

}
