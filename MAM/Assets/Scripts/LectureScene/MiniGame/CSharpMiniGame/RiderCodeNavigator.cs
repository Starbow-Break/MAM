using System.Collections.Generic;

using UnityEngine;

public class RiderCodeNavigator : MonoBehaviour
{
    [System.Serializable]
    private struct Edge
    {
        public int start;
        public int end;
    }
    
    private class NavGraphNode
    {
        public RiderCodeGroup CodeGroup;
        public List<NavGraphNode> NextNodes;

        public NavGraphNode()
        {
            NextNodes = new List<NavGraphNode>();
        }
    }
    
    [SerializeField] private List<RiderCodeGroup> _riderCodegroups;
    [SerializeField] private List<Edge> _edges;

    private List<NavGraphNode> _navNodes = new();
    private NavGraphNode _currentNode = null;
    
    private void Start()
    {
        GenerateGraph();
    }

    private void OnDisable()
    {
        _currentNode = null;
    }

    public SpriteRenderer GetCodeRenderer(EJudge judge)
    {
        if (_currentNode == null)
        {
            PickRandomNode();
        }
        
        RiderCodeGroup node = _currentNode.CodeGroup;
        GameObject code = judge switch
        {
            EJudge.Perfect => node.PerfectCode,
            var j when j == EJudge.EarlyGood || j == EJudge.LateGood
                => node.GoodCode,
            _ => node.BadCode
        };
        
        SpriteRenderer codeReanderer = CodeSpritePoolManager.Instance.Spawn(code.name, Vector3.zero, Quaternion.identity, null);

        MoveNext();

        return codeReanderer;
    }

    private void PickRandomNode()
    {
        int index = Random.Range(0, _navNodes.Count);
        _currentNode = _navNodes[index];
    }

    private void MoveNext()
    {
        int nextIndex = Random.Range(0, _currentNode.NextNodes.Count);
        _currentNode = _currentNode.NextNodes[nextIndex];
    }
    
    private void GenerateGraph()
    {
        foreach (var codeGroup in _riderCodegroups)
        {
            NavGraphNode node = new NavGraphNode();
            node.CodeGroup = codeGroup;
            _navNodes.Add(node);
        }

        foreach (var edge in _edges)
        {
            _navNodes[edge.start].NextNodes.Add(_navNodes[edge.end]);
        }
    }
}
