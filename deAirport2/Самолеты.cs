using System;
using System.Collections.Generic;

namespace deAirport2;

public partial class Самолеты
{
    public int КодСамолета { get; set; }

    public string? ТипСамолета { get; set; }

    public int? ГодВыпуска { get; set; }

    public int? КоличМест { get; set; }

    public string? ФирмаПроизводитель { get; set; }

    public virtual ICollection<Рейсы> Рейсыs { get; set; } = new List<Рейсы>();
}
