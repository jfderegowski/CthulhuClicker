using UnityEngine;

public class Item
{
    public string Name
    {
        get => _name;
        set => _name = value;
    }
    [SerializeField] private string _name;
    public ulong Price
    {
        get => _price;
        set => _price = value;
    }
    [SerializeField] private ulong _price;
    public uint Lvl
    {
        get => _lvl;
        set => _lvl = value;
    }
    [SerializeField] private uint _lvl;
    public ulong Mps
    {
        get => _mps;
        set => _mps = value;
    }
    [SerializeField] private ulong _mps;
    public Sprite Sprite
    {
        get => _sprite;
        set => _sprite = value;
    }
    [SerializeField] private Sprite _sprite;
}

public enum ItemType
{
    Wings,
    Body,
    Eye,
    Shirt,
    Hat
}