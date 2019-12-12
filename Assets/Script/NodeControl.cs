using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NodeControl : MonoBehaviour
{
    [Range(1, 12)]
    public int number = 1;
    public string displayNumber;
    public bool open = true;

    PolygonCollider2D zone;
    SpriteRenderer sp;
    MissionNodes msn;
    Text txZone;

    // Start is called before the first frame update
    void Start()
    {
        msn = GetComponentInParent<MissionNodes>();
        zone = GetComponent<PolygonCollider2D>();
        txZone = GetComponentInChildren<Text>();
        sp = GetComponent<SpriteRenderer>();

        txZone.text = displayNumber;

        sp.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (open && Input.GetMouseButtonDown(0))
        {
            Vector3 wpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mpos;
            mpos.x = wpos.x;
            mpos.y = wpos.y;

            if (zone.bounds.Contains(mpos))
            {
                // Load the scene here !
                Debug.Log($"[Map] - Clicked on chapter {number} from chapter {msn.prefix}");
                string[] names = GameObject.Find(msn.prefix).GetComponent<PinController>().SceneNames;
                Debug.Log($"[Map] - The scene to load should be {names[number - 1]}");
                if (Application.CanStreamedLevelBeLoaded(names[number - 1]) == false)
                {
                    Debug.Log("[Map] - Scene doesnt' exist, so fuck you");
                } else {
                    Config.Instance.sceneToLoad = names[number - 1];
                    //Config.Instance.loadingScene = 1;
                    SceneManager.LoadScene("Loading");
                }

            }
        }
        if (open == false)
        {
            sp.color = Color.red;
        } else
        {
            sp.color = Color.white;
        }
    }
}
