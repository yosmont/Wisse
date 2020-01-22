using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenarioThroneScene : MonoBehaviour
{
    public string _levelPath;

    private Vector3 _speed;
    private Rigidbody2D _heracles;
    private Animator _moveType;
    public Camera _cam;

    private bool _isTalking = true;
    private int _second = 0;

    public Image _black;
    public Animator _anim;

    void Start()
    {
        GameObject.Find("Héraclès").GetComponent<APNJTalk>().Talk();
        _speed = new Vector3(-1.5f, -1, 0);
        _heracles = GameObject.Find("Héraclès").GetComponent<Rigidbody2D>();
        _moveType = GameObject.Find("Héraclès").GetComponent<Animator>();
    }

    void Update()
    {
        _isTalking = GameObject.Find("Héraclès").GetComponent<DialogueThroneScene>().GetIsTalking();
        if (!_isTalking && _second == 0)
        {
            _second = 1;
            _heracles.velocity = _speed;
            _moveType.Play("Move");
            GameObject.Find("Héraclès").GetComponent<SpriteRenderer>().flipX = true;
        } else if (_second == 1 && ((_cam.WorldToViewportPoint(_heracles.position).x - 0.07 >= 1 ||
               _cam.WorldToViewportPoint(_heracles.position).x + 0.07 <= 0) ||
               (_cam.WorldToViewportPoint(_heracles.position).y + 0.07 >= 1 ||
               _cam.WorldToViewportPoint(_heracles.position).y  + 0.07 <= 0)))
        {
            _second = 3;
            GameObject.Find("Héraclès").GetComponent<APNJTalk>().Talk();
        } else if (_isTalking && _second == 3)
            StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        _anim.SetBool("Fade", true);
        yield return new WaitUntil(()=>_black.color.a == 1);
        SceneManager.LoadScene("src/scene/" + _levelPath);
    }
}
