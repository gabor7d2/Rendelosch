﻿namespace Rendelosch.Models;

public class ProductForm
{
    public readonly string Id;
    public readonly string Title;
    
    public readonly List<Field> Fields;
    
    public readonly List<Submission> Submissions = new();

    public ProductForm(string id, string title, List<Field> fields)
    {
        Id = id;
        Title = title;
        Fields = fields;
    }
}