using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelexitmanager : MonoBehaviour
{
    [SerializeField] float levelloaddelay =2f;
    [SerializeField] float levelexitslowmotionrate = 0.2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(loadnextlevel());
    }
    IEnumerator loadnextlevel()
    {
        Time.timeScale = levelexitslowmotionrate;
        yield return new WaitForSecondsRealtime(levelloaddelay);
        Time.timeScale = 1f;
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene+1);
        
    }
}
