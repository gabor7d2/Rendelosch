﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Rendelosch.Dal.Entities;

public class Field
{
    public string Key { get; set; }
    
    public string Name { get; set; }
    
}