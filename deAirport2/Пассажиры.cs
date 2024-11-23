using System;
using System.Collections.Generic;

namespace deAirport2;

public partial class Пассажиры
{
    public int КодПассажира { get; set; }

    public string? ФиоПассажира { get; set; }

    public string? Пол { get; set; }

    public string? ДатаРождения { get; set; }

    public string? СерияНомерПасспорта { get; set; }

    public string? Гражданство { get; set; }

    public virtual ICollection<Билеты> Билетыs { get; set; } = new List<Билеты>();
}
