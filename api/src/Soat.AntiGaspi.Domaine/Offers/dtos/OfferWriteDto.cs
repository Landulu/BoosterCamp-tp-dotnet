using System;

namespace Soat.AntiGaspi.Domaine.Offers.dtos;

public record OfferWriteDto
{
    private Guid _id;
    private string _title;
    private string _description;

    public OfferWriteDto(Guid id, string description, string title)
    {
        _id = id;
        _description = description;
        _title = title;
    }
}