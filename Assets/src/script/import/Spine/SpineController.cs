using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class SpineController : MonoBehaviour
{

    public float speed = 5;
    public SkeletonAnimation animation;
    float x;
    string currentAnimation = "";

    void Update() {
        x = Input.GetAxis("Horizontal") * speed;
        if (x > 0)
        {
            animation.Skeleton.FlipX = false;
            changeAnimation("walk", true);
        }
        else if (x < 0)
        {
            animation.Skeleton.FlipX = true;
            changeAnimation("walk", true);
        }
        else {
            changeAnimation("Idle", true);
        }
    }

    void changeAnimation(string name, bool state) {
        if (currentAnimation != name)
            animation.state.SetAnimation(0, name, state);
        currentAnimation = name;
    }

    void FixedUpdate() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(x, GetComponent<Rigidbody2D>().velocity.y);
    }
}
