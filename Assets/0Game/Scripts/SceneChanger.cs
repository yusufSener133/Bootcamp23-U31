using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Emre {
    public class SceneChanger : MonoBehaviour
    {
        [SerializeField] GameManager gameManager;
        [SerializeField] int sceneBuildIndex;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameManager.SceneUpload(sceneBuildIndex);
            }
        }
    }
}