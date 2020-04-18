using UnityEngine;

public class DieAfterTime:MonoBehaviour
{
    public bool beginOnStart = true;
    public bool useDieAfterTimeAtBegin = true; // for false, you can use realtime dynamic death timer.
    public FloatVarRef dieAfterTime;
    private float startTime;
    private float dieTime;

    void Start()
    {
        if (beginOnStart)
        {
            Begin();
        }
    }
    public void Begin()
    {
        startTime = Time.time;
        dieTime = dieAfterTime.Value;
    }

    void Update()
    {
        if (useDieAfterTimeAtBegin)
        {
            if (Time.time - startTime > dieTime)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (Time.time - startTime > dieAfterTime.Value)
            {
                Destroy(gameObject);
            }
        }
    }
}
