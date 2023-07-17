using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CAN
{ 
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;

        public float spawnRate = 4f;
        public GameObject enemyPrefab;

        private int enemyNum = 0;

        public int maxEnemyNum = 1;
        //private bool isGameActive = false;

        private void Start()
        {
            StartCoroutine(SpawnTarget());
        }

        private void Update()
        {
            WinTrigger();
        }

        IEnumerator SpawnTarget()
        {
            while (_gameManager.StartGame() && enemyNum <= maxEnemyNum)
            {
                enemyNum += 1;
                Instantiate(enemyPrefab, RandomSpawnPosition(), enemyPrefab.transform.rotation, transform);
                yield return new WaitForSeconds(spawnRate);
            }
        }

        void WinTrigger()
        {
            if (GetComponentsInChildren<Transform>().Length <= 1)
            {
                _gameManager.WinTrigger();
            }
        }

        Vector3 RandomSpawnPosition()
        {
            float spawnPosX = Random.Range(-30f, 30f);

            Vector3 spawnPosition = new Vector3(spawnPosX, enemyPrefab.transform.position.y);
            return spawnPosition;
        }
    }
}