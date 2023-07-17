using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DuckAnimControl : MonoBehaviour
{
    public GameObject winPanel;

    private int killCount;

    void OnMouseDown()
    {
        if(killCount == 5)
        {
            winPanel.SetActive(true);
            return;
        }

        killCount += 1;

        GetComponent<Animator>().SetTrigger("Die");

    }

    public void ResetAnim()
    {
        GetComponent<Animator>().SetTrigger("Reset");
    }


    public void quitButton(int deger)
    {
        SceneManager.LoadScene(deger);
    }
}
