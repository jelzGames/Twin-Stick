using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private Rigidbody rigiBody;
    private GameManager manager;
    private int currentFrame = -1;
    private int maxFrame = -1;
    
    private const int bufferFrames = 1000;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];

    
    // Use this for initialization
    void Start () {
        rigiBody = GetComponent<Rigidbody>();
        manager = GameObject.FindObjectOfType<GameManager>();

    }
	
	// Update is called once per frame
	void Update () {
        currentFrame += 1;
        if (currentFrame > maxFrame)
        {
            maxFrame = currentFrame;
        }
        if (currentFrame == bufferFrames)
        {
            currentFrame = 0;
        }
        if (manager.recording)
        {
            Record();
        }
        else
        {
            PlayBack();
        }



    }

    void PlayBack()
    {
        if (currentFrame == maxFrame)
        {
            currentFrame = 0;
        }
        rigiBody.isKinematic = true;
        int frame = currentFrame % maxFrame;
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;

 
    }

    void Record()
    {
        rigiBody.isKinematic = false;
        keyFrames[currentFrame] = new MyKeyFrame(transform.position, transform.rotation);
    }
}

public struct MyKeyFrame
{
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(Vector3 aPosition, Quaternion aRotation)
    {
        position = aPosition;
        rotation = aRotation;
    }

}
