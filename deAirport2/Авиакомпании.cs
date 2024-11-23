using System;
using System.Collections.Generic;

namespace deAirport2;

public partial class Авиакомпании
{
    public int КодАвиакомпании { get; set; }

    public string? НазваниеАвиакомпании { get; set; }

    public string? ШтабКвартира { get; set; }

    public virtual ICollection<Рейсы> Рейсыs { get; set; } = new List<Рейсы>();
}
