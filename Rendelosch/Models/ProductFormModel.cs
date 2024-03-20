﻿using System.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Rendelosch.Models;

public class ProductFormModel
{
    public string Id { get; set; }
    
    public string Title { get; set; }
    
    public List<FieldModel> Fields { get; set; }
    
}