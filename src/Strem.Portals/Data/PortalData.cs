﻿using Strem.Portals.Types;

namespace Strem.Portals.Data;

public class PortalData
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ButtonSize ButtonSize { get; set; }
    public bool ShowTodos { get; set; }
    public List<string> TodoTags { get; set; } = new();
    public List<ButtonData> Buttons { get; set; } = new();

    public PortalData(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public PortalData()
    {
    }
}
