using UnityEngine;

public class DieAfterTime:MonoBehaviour
{
    public bool beginOnStart = true;
    public FloatVarRef dieAfterTime;

    void Start()
    {
        if (beginOnStart)
        {
            Begin();
        }
    }
    public void Begin()
    {
        Destroy(gameObject, dieAfterTime.Value);
    }
}
