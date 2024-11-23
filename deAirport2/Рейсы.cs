using System;
using System.Collections.Generic;

namespace deAirport2;

public partial class Рейсы
{
    public string НомерРейса { get; set; } = null!;

    public string? ПунктОтправления { get; set; }

    public string? ПунктПрибытия { get; set; }

    public string? ВремяВылета { get; set; }

    public int? КодСамолета { get; set; }

    public int? КодАвиакомпании { get; set; }

    public string? ВремяПути { get; set; }

    public virtual ICollection<Билеты> Билетыs { get; set; } = new List<Билеты>();

    public virtual Авиакомпании? КодАвиакомпанииNavigation { get; set; }

    public virtual Самолеты? КодСамолетаNavigation { get; set; }
}
