using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("PacDot") == null)
        {
            SceneManager.LoadScene("MainLevel");
        }
        else
        {
            Debug.Log("Not Finished");
        }
    }
}
