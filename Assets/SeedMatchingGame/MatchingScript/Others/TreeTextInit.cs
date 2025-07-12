using UnityEngine;

public class TreeTextInit : MonoBehaviour
{
    public GetTreeID[] allTrees;

    void Start()
    {
        foreach (var tree in allTrees)
        {
            TreeTextFader.Instance.FadeOutAndDisable(tree.GetTreeName());
        }
    }
}