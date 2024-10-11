using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public GameObject[] playerColors, enemyColors, spawners;
    public static int colorSelected;
    public static bool playerAlive;

    float timerMin = 1f, timerMax = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        colorSelected = 0;
        playerAlive = true;

        StartCoroutine("Spawner");
    }

    IEnumerator Spawner()
    {
        int i;
        while (true)
        {
            i = Random.Range(0, 3);
            yield return new WaitForSeconds(Random.Range(timerMin, timerMax));
            Instantiate(enemyColors[Random.Range(0,2)], spawners[i].transform.position, spawners[i].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //manages player color
        if(Input.GetMouseButtonDown(0))
        {
            playerColors[colorSelected].SetActive(false);

            if (colorSelected >= 2)
            {
                colorSelected = 0;
            }
            else
            {
                colorSelected++;
            }
            
            playerColors[colorSelected].SetActive(true);
        }

        if(playerAlive == false)
        {
            SceneManager.LoadSceneAsync("GameOver");
        }
    }
}
