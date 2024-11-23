using System;
using System.Collections.Generic;

namespace deAirport2;

public partial class Билеты
{
    public int НомерБилета { get; set; }

    public string? НомерРейса { get; set; }

    public int? КодПассажира { get; set; }

    public int? НомерМеста { get; set; }

    public int? Стоимость { get; set; }

    public string? ДатаПродажи { get; set; }

    public string? ДатаБронирования { get; set; }

    public virtual Пассажиры? КодПассажираNavigation { get; set; }

    public virtual Рейсы? НомерРейсаNavigation { get; set; }
}
