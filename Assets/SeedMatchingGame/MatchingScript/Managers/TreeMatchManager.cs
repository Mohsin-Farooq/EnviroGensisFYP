using UnityEngine;

public class TreeMatchManager : ITreeMatcher
{
    public bool TryMatch(RaycastHit2D hit, int seedID, out int matchedTreeID)
    {
        matchedTreeID = -1;

        if (hit.collider != null && hit.collider.TryGetComponent(out GetTreeID tree))
        {
            matchedTreeID = tree.GetMatchID();
            if (matchedTreeID == seedID)
            {
                if (GeneralAudioManager.Instance != null)
                {
                    GeneralAudioManager.Instance.PlaySound(SoundType.Match);
                }
                TreeTextFader.Instance.FadeInAndEnable(tree.GetTreeName());
                return true;
            }
            else
            {
                if (GeneralAudioManager.Instance != null)
                {
                    GeneralAudioManager.Instance.PlaySound(SoundType.Fail);
                }
            }
        }

        return false;
    }
}