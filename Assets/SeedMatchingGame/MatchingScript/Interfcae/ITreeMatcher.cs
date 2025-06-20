using UnityEngine;

public interface ITreeMatcher
{
    bool TryMatch(RaycastHit2D hit, int seedID, out int matchedTreeID);
}