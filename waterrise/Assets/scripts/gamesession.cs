using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gamesession : MonoBehaviour
{
    [SerializeField] int playerlives=3;
    [SerializeField] int score=0;
    [SerializeField] Text skortxt,livetxt;
    private void Awake()
    {
        int numgamesession = FindObjectsOfType<gamesession>().Length;
        if(numgamesession>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
       
         livetxt.text = playerlives.ToString();
        skortxt.text = score.ToString();

    }
    public void addtoscore(int pointstoadd)
    {
        score += pointstoadd;
        skortxt.text = score.ToString();
    }
    public void processplayer()
    {
            if(playerlives>1)
        {
            playerlives--;
            int currentscene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentscene);
            livetxt.text = playerlives.ToString();

        }
            else
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }
    }
  
    void Update()
    {
       
    }
}
