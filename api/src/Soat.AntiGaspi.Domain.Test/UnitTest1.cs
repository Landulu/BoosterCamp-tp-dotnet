using System;
using NUnit.Framework;
using Soat.AntiGaspi.Domain.Offers;

namespace Soat.AntiGaspi.Domain.Test;

public class Tests
{

    private DateTimeOffset _utcNow;
    
    [SetUp]
    public void Setup()
    {
         _utcNow = DateTimeOffset.Now;
    }

    [Test]
    public void OfferShouldNotCreateWhenExpirationDateIsPassed()
    {
        var yesterday = DateTimeOffset.Now.AddDays(-1);

        var sut = Offer.CreateNew(
            new OfferId(Guid.NewGuid()),
            "title",
            "description",
            "email@mail.com",
            "company name",
            "address 75757 Some city",
            null,
            yesterday,
            _utcNow
        );
        Assert.False(sut.Success);
        Assert.AreEqual("expiration_passed_on_creation", sut.Error);
    }
}