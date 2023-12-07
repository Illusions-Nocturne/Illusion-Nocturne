using UnityEngine;
using UnityEngine.SceneManagement;
public class Victory : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.loadedSceneCount-1);
        }
    }
}
