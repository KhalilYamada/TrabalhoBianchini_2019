using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditsController : MonoBehaviour
{
    /*private RectTransform r;
    private void Start()
    {
        r = GetComponent<RectTransform>();
    }
    */

    void Update()
    {
        /*
        Vector2 p = r.anchoredPosition;
        p.y += 5 * Time.deltaTime;
        r.anchoredPosition = p;
        */

        if(Input.anyKey || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(0);
    }

}
