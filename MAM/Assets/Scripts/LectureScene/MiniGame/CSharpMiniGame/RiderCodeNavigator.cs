using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RiderCodeNavigator : MonoBehaviour
{
    [SerializeField] private List<RiderCodeGroup> _riderCodegroups;
    [SerializeField] private List<Edge> _edges;

    private readonly List<NavGraphNode> _navNodes = new();
    private NavGraphNode _currentNode;

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
        if (_currentNode == null) PickRandomNode();

        var node = _currentNode.CodeGroup;
        var code = judge switch
        {
            EJudge.Perfect => node.PerfectCode,
            var j when j == EJudge.EarlyGood || j == EJudge.LateGood
                => node.GoodCode,
            _ => node.BadCode
        };

        var codeReanderer = CodeSpritePoolManager.Instance.Spawn(code.name, Vector3.zero, Quaternion.identity, null);

        MoveNext();

        return codeReanderer;
    }

    private void PickRandomNode()
    {
        var index = Random.Range(0, _navNodes.Count);
        _currentNode = _navNodes[index];
    }

    private void MoveNext()
    {
        var nextIndex = Random.Range(0, _currentNode.NextNodes.Count);
        _currentNode = _currentNode.NextNodes[nextIndex];
    }

    private void GenerateGraph()
    {
        foreach (var codeGroup in _riderCodegroups)
        {
            var node = new NavGraphNode();
            node.CodeGroup = codeGroup;
            _navNodes.Add(node);
        }

        foreach (var edge in _edges) _navNodes[edge.start].NextNodes.Add(_navNodes[edge.end]);
    }

    [Serializable]
    private struct Edge
    {
        public int start;
        public int end;
    }

    private class NavGraphNode
    {
        public readonly List<NavGraphNode> NextNodes;
        public RiderCodeGroup CodeGroup;

        public NavGraphNode()
        {
            NextNodes = new List<NavGraphNode>();
        }
    }
}