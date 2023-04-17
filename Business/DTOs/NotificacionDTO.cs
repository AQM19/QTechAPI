﻿using System;
using System.Collections.Generic;

namespace Business.DTOs;
public partial class NotificacionDTO
{
    public long Id { get; set; }

    public long Idterrario { get; set; }

    public DateTime Fecha { get; set; }

    public string Texto { get; set; } = null!;

    public sbyte Vista { get; set; }
}
