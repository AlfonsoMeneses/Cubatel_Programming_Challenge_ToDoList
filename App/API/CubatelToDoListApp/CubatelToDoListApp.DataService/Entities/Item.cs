using System;
using System.Collections.Generic;

namespace CubatelToDoListApp.DataService.Entities;

public partial class Item
{
    public int IdItem { get; set; }

    public int? TaskId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public short? IsCompleted { get; set; }

    public virtual Task? Task { get; set; }
}
