using System;
using JetBrains.Annotations;
using UnityEngine;

[Serializable]
public class Castle
{
    public Vector2Int Size;
    public Story[] Stories ;
    public Tower[] Towers;
    public CastleShape CastleShape;

    public Castle(Vector2Int size, Story[] standardStories)
    {
        Size = size;
        Stories = standardStories;
    }

    public Castle(Vector2Int size, Story[] stories, Tower[] towers, CastleShape castleShape)
    {
        Size = size;
        Stories = stories;
        Towers = towers;
        CastleShape = castleShape;
    }
}
