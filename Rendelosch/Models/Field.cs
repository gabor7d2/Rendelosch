namespace Rendelosch.Models;

public class Field
{
    public readonly string Key;
    
    public readonly string Name;

    public Field(string key, string name)
    {
        Key = key;
        Name = name;
    }
}