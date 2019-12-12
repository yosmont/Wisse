using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGame : MonoBehaviour
{
    public string levelPath;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 InputWorldPoint = Vector3.zero;
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.Lumin || Application.platform == RuntimePlatform.IPhonePlayer) {
            if (Input.touchCount > 0) {
                if (Input.touches[0].phase == TouchPhase.Began) {
                    InputWorldPoint = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
                }
            }
        } else {
            if (Input.GetMouseButtonDown(0)) {
                InputWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        if (InputWorldPoint != Vector3.zero) {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(InputWorldPoint.x, InputWorldPoint.y), Vector2.zero);
            if (hit.collider.name == "lion")
                SceneManager.LoadScene(levelPath);
        }
    }
}
