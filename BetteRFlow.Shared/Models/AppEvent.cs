using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetteRFlow.Shared.Models;
public class AppEvent
{
    public int Id { get; set; }
    public string EventType { get; set; } = string.Empty; // Register, Login, CreateBrf
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

