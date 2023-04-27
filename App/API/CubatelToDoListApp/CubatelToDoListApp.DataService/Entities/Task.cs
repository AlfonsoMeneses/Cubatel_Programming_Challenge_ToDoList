using System;
using System.Collections.Generic;

namespace CubatelToDoListApp.DataService.Entities;

public partial class Task
{
    public int IdTask { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
