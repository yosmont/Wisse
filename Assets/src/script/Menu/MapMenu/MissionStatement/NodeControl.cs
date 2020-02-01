using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NodeControl : MonoBehaviour
{
    [Range(1, 12)]
    public int _number = 1;
    public string _displayNumber;
    public bool _open = true;

    private PolygonCollider2D _zone;
    private SpriteRenderer _sp;
    private MissionNodes _msn;
    private Text _txZone;

    // Start is called before the first frame update
    void Start()
    {
        _msn = GetComponentInParent<MissionNodes>();
        _zone = GetComponent<PolygonCollider2D>();
        _txZone = GetComponentInChildren<Text>();
        _sp = GetComponent<SpriteRenderer>();

        _txZone.text = _displayNumber;

        _sp.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (_open && Input.GetMouseButtonDown(0))
        {
            Vector3 wpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mpos;
            mpos.x = wpos.x;
            mpos.y = wpos.y;

            if (_zone.bounds.Contains(mpos))
            {
                // Load the scene here !
                Debug.Log($"[Map] - Clicked on chapter {_number} from chapter {_msn._prefix}");
                string[] names = GameObject.Find(_msn._prefix).GetComponent<PinController>()._sceneNames;
                Debug.Log($"[Map] - The scene to load should be {names[_number - 1]}");
                if (Application.CanStreamedLevelBeLoaded(names[_number - 1]) == false)
                {
                    Debug.Log("[Map] - Scene doesnt' exist, so fuck you");
                } else {
                    Config.Instance.sceneToLoad = names[_number - 1];
                    //Config.Instance.loadingScene = 1;
                    SceneManager.LoadScene("Loading");
                }

            }
        }
        if (_open == false)
        {
            _sp.color = Color.red;
        } else
        {
            _sp.color = Color.white;
        }
    }
}
