using System.Collections.Generic;
using UnityEngine;

// ReSharper disable All
public class TeamButtonSetter : MonoBehaviour
{
    [SerializeField] TeamButtonUpdater _updater;
    [SerializeField] Transform _parent;
    
    private List<TeamButtonUpdater> _updaters = new List<TeamButtonUpdater>();

    public void Initialize(int count)
    {
        for (int i = 0; i < count; i++)
        {
            TeamButtonUpdater newUpdater = Instantiate(_updater, _parent);
            _updaters.Add(newUpdater);
        }
    }
}
