using UnityEngine;

public class TreeMatchManager : ITreeMatcher
{
    public bool TryMatch(RaycastHit2D hit, int seedID, out int matchedTreeID)
    {
        matchedTreeID = -1;

        if (hit.collider != null && hit.collider.TryGetComponent(out GetTreeID tree))
        {
            matchedTreeID = tree.GetMatchID();
            return matchedTreeID == seedID;
        }

        return false;
    }
}