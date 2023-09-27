using System;
using System.Collections.Generic;

namespace Backend_Personal_Doctor.Models.Naehrwerte.DTOs;

public partial class EfNaehrwert
{
    public int NahrungId { get; set; }

    public string Essen { get; set; }

    public decimal? Brennwert { get; set; }

    public decimal? Proteingehalt { get; set; }

    public decimal? Kohlenhydrate { get; set; }

    public decimal? Zucker { get; set; }

    public decimal? Fett { get; set; }
}
