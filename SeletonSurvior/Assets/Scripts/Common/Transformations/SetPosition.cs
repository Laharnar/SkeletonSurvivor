using UnityEngine;

public class SetPosition:MonoBehaviour
{
    [Header("Random")]
    public BoolVarValue setRandom;
    public RectVarValue randomAreaAround;

    [Header("Controlled")]
    public IntVarValue active;
    public Vector3[] relativePositions;
    public TransformVarValue target;

    void Awake()
    {
        target.Value = transform;
    }

    public void Next()
    {
        active.Value = (active.Value+1)%relativePositions.Length;
    }

    public void SetToSelectedPosition()
    {
        if (setRandom.Value)
        {
            target.Value.localPosition = NewRandom(randomAreaAround.Value);
        }
        else
        {
            target.Value.localPosition = relativePositions[active.Value];
        }
    }

    Vector2 NewRandom(Rect rect)
    {
        return new Vector2(
            randomAreaAround.Value.x + Random.value * randomAreaAround.Value.width,
            randomAreaAround.Value.y + Random.value * randomAreaAround.Value.height);
    }
}