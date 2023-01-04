using System;
using System.Collections.Generic;

namespace TelefonRehberi.Models;

public partial class Kisiler
{
    public int KisilerId { get; set; }

    public string KisiAdi { get; set; } = null!;

    public string KisiSoyadi { get; set; } = null!;

    public string TelefonNo { get; set; } = null!;
}
