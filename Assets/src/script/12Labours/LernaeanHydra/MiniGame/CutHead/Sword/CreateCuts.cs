using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	
public class CreateCuts : MonoBehaviour
{

    [SerializeField]
    private GameObject _cut;
    [SerializeField]
    private float _cutDestroyTime;

    private bool _dragging = false;
    private Vector2 _swipeStart;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            _dragging = true;
            _swipeStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        } else if (Input.GetMouseButtonUp(0) && _dragging) {
            CreateCut();
        }
    }

    private void CreateCut()
    {
        _dragging = false;
        Vector2 swipeEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject cut = Instantiate(_cut, _swipeStart, Quaternion.identity) as GameObject;
        cut.GetComponent<LineRenderer>().SetPosition(0, _swipeStart);
        cut.GetComponent<LineRenderer>().SetPosition(1, swipeEnd);
        Vector2[] colliderPoints = new Vector2[2];
        colliderPoints[0] = new Vector2(0.0f, 0.0f);
        colliderPoints[1] = swipeEnd - _swipeStart;
        cut.GetComponent<EdgeCollider2D>().points = colliderPoints;
        Destroy(cut.gameObject, _cutDestroyTime);
    }
}
