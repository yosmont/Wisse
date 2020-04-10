using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class SpineChangeAttachement : MonoBehaviour
{

    [SpineSlot]
    public string slot;

    [SpineAttachment(currentSkinOnly: true, slotField: "slot")]
    public string replace;

    public SkeletonAnimation animation;

    void Start()
    {
        animation.skeleton.SetAttachment(slot, replace);
    }


    void Update()
    {
        
    }
}
